#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl alpha animation class</summary>
[AnimationAlphaNativeInherit]
public class AnimationAlpha : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationAlphaNativeInherit nativeInherit = new Efl.Canvas.AnimationAlphaNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationAlpha))
            return Efl.Canvas.AnimationAlphaNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AnimationAlpha obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_alpha_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AnimationAlpha(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AnimationAlpha", efl_canvas_animation_alpha_class_get(), typeof(AnimationAlpha), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AnimationAlpha(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimationAlpha(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationAlpha static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationAlpha(obj.NativeHandle);
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
    protected static extern  void efl_animation_alpha_get(System.IntPtr obj,   out double from_alpha,   out double to_alpha);
   /// <summary>Alpha property</summary>
   /// <param name="from_alpha">Alpha value when animation starts</param>
   /// <param name="to_alpha">Alpha value when animation ends</param>
   /// <returns></returns>
   virtual public  void GetAlpha( out double from_alpha,  out double to_alpha) {
                                           efl_animation_alpha_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_alpha,  out to_alpha);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_alpha_set(System.IntPtr obj,   double from_alpha,   double to_alpha);
   /// <summary>Alpha property</summary>
   /// <param name="from_alpha">Alpha value when animation starts</param>
   /// <param name="to_alpha">Alpha value when animation ends</param>
   /// <returns></returns>
   virtual public  void SetAlpha( double from_alpha,  double to_alpha) {
                                           efl_animation_alpha_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_alpha,  to_alpha);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class AnimationAlphaNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_alpha_get_static_delegate = new efl_animation_alpha_get_delegate(alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_alpha_get_static_delegate)});
      efl_animation_alpha_set_static_delegate = new efl_animation_alpha_set_delegate(alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_alpha_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationAlpha.efl_canvas_animation_alpha_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationAlpha.efl_canvas_animation_alpha_class_get();
   }


    private delegate  void efl_animation_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_alpha,   out double to_alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_alpha_get(System.IntPtr obj,   out double from_alpha,   out double to_alpha);
    private static  void alpha_get(System.IntPtr obj, System.IntPtr pd,  out double from_alpha,  out double to_alpha)
   {
      Eina.Log.Debug("function efl_animation_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           from_alpha = default(double);      to_alpha = default(double);                     
         try {
            ((AnimationAlpha)wrapper).GetAlpha( out from_alpha,  out to_alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_animation_alpha_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_alpha,  out to_alpha);
      }
   }
   private efl_animation_alpha_get_delegate efl_animation_alpha_get_static_delegate;


    private delegate  void efl_animation_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_alpha,   double to_alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_alpha_set(System.IntPtr obj,   double from_alpha,   double to_alpha);
    private static  void alpha_set(System.IntPtr obj, System.IntPtr pd,  double from_alpha,  double to_alpha)
   {
      Eina.Log.Debug("function efl_animation_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((AnimationAlpha)wrapper).SetAlpha( from_alpha,  to_alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_animation_alpha_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_alpha,  to_alpha);
      }
   }
   private efl_animation_alpha_set_delegate efl_animation_alpha_set_static_delegate;
}
} } 
