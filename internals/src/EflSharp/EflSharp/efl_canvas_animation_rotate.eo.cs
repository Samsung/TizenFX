#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl rotate animation class</summary>
[AnimationRotateNativeInherit]
public class AnimationRotate : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationRotateNativeInherit nativeInherit = new Efl.Canvas.AnimationRotateNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationRotate))
            return Efl.Canvas.AnimationRotateNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AnimationRotate obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_rotate_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AnimationRotate(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AnimationRotate", efl_canvas_animation_rotate_class_get(), typeof(AnimationRotate), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AnimationRotate(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimationRotate(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationRotate static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationRotate(obj.NativeHandle);
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
    protected static extern  void efl_animation_rotate_get(System.IntPtr obj,   out double from_degree,   out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
   /// <summary>Rotate property</summary>
   /// <param name="from_degree">Rotation degree when animation starts</param>
   /// <param name="to_degree">Rotation degree when animation ends</param>
   /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
   /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
   /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
   /// <returns></returns>
   virtual public  void GetRotate( out double from_degree,  out double to_degree,  out Efl.Canvas.Object pivot,  out double cx,  out double cy) {
                                                                                                 efl_animation_rotate_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_rotate_set(System.IntPtr obj,   double from_degree,   double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
   /// <summary>Rotate property</summary>
   /// <param name="from_degree">Rotation degree when animation starts</param>
   /// <param name="to_degree">Rotation degree when animation ends</param>
   /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
   /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
   /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
   /// <returns></returns>
   virtual public  void SetRotate( double from_degree,  double to_degree,  Efl.Canvas.Object pivot,  double cx,  double cy) {
                                                                                                 efl_animation_rotate_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_degree,  to_degree,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_rotate_absolute_get(System.IntPtr obj,   out double from_degree,   out double to_degree,   out  int cx,   out  int cy);
   /// <summary>Rotate absolute property</summary>
   /// <param name="from_degree">Rotation degree when animation starts</param>
   /// <param name="to_degree">Rotation degree when animation ends</param>
   /// <param name="cx">X absolute coordinate of the center point.</param>
   /// <param name="cy">Y absolute coordinate of the center point.</param>
   /// <returns></returns>
   virtual public  void GetRotateAbsolute( out double from_degree,  out double to_degree,  out  int cx,  out  int cy) {
                                                                               efl_animation_rotate_absolute_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_degree,  out to_degree,  out cx,  out cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_rotate_absolute_set(System.IntPtr obj,   double from_degree,   double to_degree,    int cx,    int cy);
   /// <summary>Rotate absolute property</summary>
   /// <param name="from_degree">Rotation degree when animation starts</param>
   /// <param name="to_degree">Rotation degree when animation ends</param>
   /// <param name="cx">X absolute coordinate of the center point.</param>
   /// <param name="cy">Y absolute coordinate of the center point.</param>
   /// <returns></returns>
   virtual public  void SetRotateAbsolute( double from_degree,  double to_degree,   int cx,   int cy) {
                                                                               efl_animation_rotate_absolute_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_degree,  to_degree,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
}
public class AnimationRotateNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_rotate_get_static_delegate = new efl_animation_rotate_get_delegate(rotate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_rotate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_get_static_delegate)});
      efl_animation_rotate_set_static_delegate = new efl_animation_rotate_set_delegate(rotate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_rotate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_set_static_delegate)});
      efl_animation_rotate_absolute_get_static_delegate = new efl_animation_rotate_absolute_get_delegate(rotate_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_rotate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_get_static_delegate)});
      efl_animation_rotate_absolute_set_static_delegate = new efl_animation_rotate_absolute_set_delegate(rotate_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_rotate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationRotate.efl_canvas_animation_rotate_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationRotate.efl_canvas_animation_rotate_class_get();
   }


    private delegate  void efl_animation_rotate_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_degree,   out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_rotate_get(System.IntPtr obj,   out double from_degree,   out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
    private static  void rotate_get(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out Efl.Canvas.Object pivot,  out double cx,  out double cy)
   {
      Eina.Log.Debug("function efl_animation_rotate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             from_degree = default(double);      to_degree = default(double);      pivot = default(Efl.Canvas.Object);      cx = default(double);      cy = default(double);                                       
         try {
            ((AnimationRotate)wrapper).GetRotate( out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_animation_rotate_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
      }
   }
   private efl_animation_rotate_get_delegate efl_animation_rotate_get_static_delegate;


    private delegate  void efl_animation_rotate_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_degree,   double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_rotate_set(System.IntPtr obj,   double from_degree,   double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
    private static  void rotate_set(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,  Efl.Canvas.Object pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_animation_rotate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((AnimationRotate)wrapper).SetRotate( from_degree,  to_degree,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_animation_rotate_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_degree,  to_degree,  pivot,  cx,  cy);
      }
   }
   private efl_animation_rotate_set_delegate efl_animation_rotate_set_static_delegate;


    private delegate  void efl_animation_rotate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_degree,   out double to_degree,   out  int cx,   out  int cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_rotate_absolute_get(System.IntPtr obj,   out double from_degree,   out double to_degree,   out  int cx,   out  int cy);
    private static  void rotate_absolute_get(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out  int cx,  out  int cy)
   {
      Eina.Log.Debug("function efl_animation_rotate_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       from_degree = default(double);      to_degree = default(double);      cx = default( int);      cy = default( int);                                 
         try {
            ((AnimationRotate)wrapper).GetRotateAbsolute( out from_degree,  out to_degree,  out cx,  out cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_rotate_absolute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_degree,  out to_degree,  out cx,  out cy);
      }
   }
   private efl_animation_rotate_absolute_get_delegate efl_animation_rotate_absolute_get_static_delegate;


    private delegate  void efl_animation_rotate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_degree,   double to_degree,    int cx,    int cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_rotate_absolute_set(System.IntPtr obj,   double from_degree,   double to_degree,    int cx,    int cy);
    private static  void rotate_absolute_set(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,   int cx,   int cy)
   {
      Eina.Log.Debug("function efl_animation_rotate_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((AnimationRotate)wrapper).SetRotateAbsolute( from_degree,  to_degree,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_rotate_absolute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_degree,  to_degree,  cx,  cy);
      }
   }
   private efl_animation_rotate_absolute_set_delegate efl_animation_rotate_absolute_set_static_delegate;
}
} } 
