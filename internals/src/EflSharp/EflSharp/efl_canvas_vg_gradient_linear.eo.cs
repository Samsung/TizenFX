#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Vg { 
/// <summary>Efl vector graphics gradient linear class</summary>
[GradientLinearNativeInherit]
public class GradientLinear : Efl.Canvas.Vg.Gradient, Efl.Eo.IWrapper,Efl.Gfx.GradientLinear
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.Vg.GradientLinearNativeInherit nativeInherit = new Efl.Canvas.Vg.GradientLinearNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (GradientLinear))
            return Efl.Canvas.Vg.GradientLinearNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(GradientLinear obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_vg_gradient_linear_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public GradientLinear(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("GradientLinear", efl_canvas_vg_gradient_linear_class_get(), typeof(GradientLinear), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected GradientLinear(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public GradientLinear(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static GradientLinear static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new GradientLinear(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_linear_start_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Gets the start point of this linear gradient.</summary>
   /// <param name="x">X co-ordinate of start point</param>
   /// <param name="y">Y co-ordinate of start point</param>
   /// <returns></returns>
   virtual public  void GetStart( out double x,  out double y) {
                                           efl_gfx_gradient_linear_start_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_linear_start_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Sets the start point of this linear gradient.</summary>
   /// <param name="x">X co-ordinate of start point</param>
   /// <param name="y">Y co-ordinate of start point</param>
   /// <returns></returns>
   virtual public  void SetStart( double x,  double y) {
                                           efl_gfx_gradient_linear_start_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_linear_end_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Gets the end point of this linear gradient.</summary>
   /// <param name="x">X co-ordinate of end point</param>
   /// <param name="y">Y co-ordinate of end point</param>
   /// <returns></returns>
   virtual public  void GetEnd( out double x,  out double y) {
                                           efl_gfx_gradient_linear_end_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_gradient_linear_end_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Sets the end point of this linear gradient.</summary>
   /// <param name="x">X co-ordinate of end point</param>
   /// <param name="y">Y co-ordinate of end point</param>
   /// <returns></returns>
   virtual public  void SetEnd( double x,  double y) {
                                           efl_gfx_gradient_linear_end_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class GradientLinearNativeInherit : Efl.Canvas.Vg.GradientNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_gradient_linear_start_get_static_delegate = new efl_gfx_gradient_linear_start_get_delegate(start_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_linear_start_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_start_get_static_delegate)});
      efl_gfx_gradient_linear_start_set_static_delegate = new efl_gfx_gradient_linear_start_set_delegate(start_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_linear_start_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_start_set_static_delegate)});
      efl_gfx_gradient_linear_end_get_static_delegate = new efl_gfx_gradient_linear_end_get_delegate(end_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_linear_end_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_end_get_static_delegate)});
      efl_gfx_gradient_linear_end_set_static_delegate = new efl_gfx_gradient_linear_end_set_delegate(end_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_linear_end_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_end_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Vg.GradientLinear.efl_canvas_vg_gradient_linear_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Vg.GradientLinear.efl_canvas_vg_gradient_linear_class_get();
   }


    private delegate  void efl_gfx_gradient_linear_start_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_linear_start_get(System.IntPtr obj,   out double x,   out double y);
    private static  void start_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_linear_start_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientLinear)wrapper).GetStart( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_linear_start_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_gradient_linear_start_get_delegate efl_gfx_gradient_linear_start_get_static_delegate;


    private delegate  void efl_gfx_gradient_linear_start_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_linear_start_set(System.IntPtr obj,   double x,   double y);
    private static  void start_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_linear_start_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientLinear)wrapper).SetStart( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_linear_start_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_gradient_linear_start_set_delegate efl_gfx_gradient_linear_start_set_static_delegate;


    private delegate  void efl_gfx_gradient_linear_end_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_linear_end_get(System.IntPtr obj,   out double x,   out double y);
    private static  void end_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_linear_end_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientLinear)wrapper).GetEnd( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_linear_end_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_gradient_linear_end_get_delegate efl_gfx_gradient_linear_end_get_static_delegate;


    private delegate  void efl_gfx_gradient_linear_end_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_linear_end_set(System.IntPtr obj,   double x,   double y);
    private static  void end_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_linear_end_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientLinear)wrapper).SetEnd( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_linear_end_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_gradient_linear_end_set_delegate efl_gfx_gradient_linear_end_set_static_delegate;
}
} } } 
