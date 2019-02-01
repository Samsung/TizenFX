#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl scale animation class</summary>
[AnimationScaleNativeInherit]
public class AnimationScale : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationScaleNativeInherit nativeInherit = new Efl.Canvas.AnimationScaleNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationScale))
            return Efl.Canvas.AnimationScaleNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AnimationScale obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_scale_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AnimationScale(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AnimationScale", efl_canvas_animation_scale_class_get(), typeof(AnimationScale), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AnimationScale(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimationScale(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationScale static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationScale(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_scale_get(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
   /// <summary>Scale property</summary>
   /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
   /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
   /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
   /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
   /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is scaled on itself.</param>
   /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
   /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
   /// <returns></returns>
   virtual public  void GetScale( out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out Efl.Canvas.Object pivot,  out double cx,  out double cy) {
                                                                                                                                     efl_animation_scale_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_scale_set(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
   /// <summary>Scale property</summary>
   /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
   /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
   /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
   /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
   /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is scaled on itself.</param>
   /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
   /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
   /// <returns></returns>
   virtual public  void SetScale( double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  Efl.Canvas.Object pivot,  double cx,  double cy) {
                                                                                                                                     efl_animation_scale_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_scale_absolute_get(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y,   out  int cx,   out  int cy);
   /// <summary>Scale absolute property</summary>
   /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
   /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
   /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
   /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
   /// <param name="cx">X absolute coordinate of the center point.</param>
   /// <param name="cy">Y absolute coordinate of the center point.</param>
   /// <returns></returns>
   virtual public  void GetScaleAbsolute( out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out  int cx,  out  int cy) {
                                                                                                                   efl_animation_scale_absolute_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_scale_absolute_set(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y,    int cx,    int cy);
   /// <summary>Scale absolute property</summary>
   /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
   /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
   /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
   /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
   /// <param name="cx">X absolute coordinate of the center point.</param>
   /// <param name="cy">Y absolute coordinate of the center point.</param>
   /// <returns></returns>
   virtual public  void SetScaleAbsolute( double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,   int cx,   int cy) {
                                                                                                                   efl_animation_scale_absolute_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }
}
public class AnimationScaleNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_scale_get_static_delegate = new efl_animation_scale_get_delegate(scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_get_static_delegate)});
      efl_animation_scale_set_static_delegate = new efl_animation_scale_set_delegate(scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_set_static_delegate)});
      efl_animation_scale_absolute_get_static_delegate = new efl_animation_scale_absolute_get_delegate(scale_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_scale_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_absolute_get_static_delegate)});
      efl_animation_scale_absolute_set_static_delegate = new efl_animation_scale_absolute_set_delegate(scale_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_scale_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_absolute_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationScale.efl_canvas_animation_scale_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationScale.efl_canvas_animation_scale_class_get();
   }


    private delegate  void efl_animation_scale_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_scale_get(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
    private static  void scale_get(System.IntPtr obj, System.IntPtr pd,  out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out Efl.Canvas.Object pivot,  out double cx,  out double cy)
   {
      Eina.Log.Debug("function efl_animation_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                         from_scale_x = default(double);      from_scale_y = default(double);      to_scale_x = default(double);      to_scale_y = default(double);      pivot = default(Efl.Canvas.Object);      cx = default(double);      cy = default(double);                                                   
         try {
            ((AnimationScale)wrapper).GetScale( out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_animation_scale_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
      }
   }
   private efl_animation_scale_get_delegate efl_animation_scale_get_static_delegate;


    private delegate  void efl_animation_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_scale_set(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
    private static  void scale_set(System.IntPtr obj, System.IntPtr pd,  double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  Efl.Canvas.Object pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_animation_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((AnimationScale)wrapper).SetScale( from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_animation_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
      }
   }
   private efl_animation_scale_set_delegate efl_animation_scale_set_static_delegate;


    private delegate  void efl_animation_scale_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y,   out  int cx,   out  int cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_scale_absolute_get(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y,   out  int cx,   out  int cy);
    private static  void scale_absolute_get(System.IntPtr obj, System.IntPtr pd,  out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out  int cx,  out  int cy)
   {
      Eina.Log.Debug("function efl_animation_scale_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   from_scale_x = default(double);      from_scale_y = default(double);      to_scale_x = default(double);      to_scale_y = default(double);      cx = default( int);      cy = default( int);                                             
         try {
            ((AnimationScale)wrapper).GetScaleAbsolute( out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_animation_scale_absolute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
      }
   }
   private efl_animation_scale_absolute_get_delegate efl_animation_scale_absolute_get_static_delegate;


    private delegate  void efl_animation_scale_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y,    int cx,    int cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_scale_absolute_set(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y,    int cx,    int cy);
    private static  void scale_absolute_set(System.IntPtr obj, System.IntPtr pd,  double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,   int cx,   int cy)
   {
      Eina.Log.Debug("function efl_animation_scale_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((AnimationScale)wrapper).SetScaleAbsolute( from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_animation_scale_absolute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
      }
   }
   private efl_animation_scale_absolute_set_delegate efl_animation_scale_absolute_set_static_delegate;
}
} } 
