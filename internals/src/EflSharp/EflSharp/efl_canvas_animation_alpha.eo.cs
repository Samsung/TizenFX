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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_alpha_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public AnimationAlpha(Efl.Object parent= null
         ) :
      base(efl_canvas_animation_alpha_class_get(), typeof(AnimationAlpha), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public AnimationAlpha(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected AnimationAlpha(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>Alpha property</summary>
   /// <param name="from_alpha">Alpha value when animation starts</param>
   /// <param name="to_alpha">Alpha value when animation ends</param>
   /// <returns></returns>
   virtual public  void GetAlpha( out double from_alpha,  out double to_alpha) {
                                           Efl.Canvas.AnimationAlphaNativeInherit.efl_animation_alpha_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from_alpha,  out to_alpha);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Alpha property</summary>
   /// <param name="from_alpha">Alpha value when animation starts</param>
   /// <param name="to_alpha">Alpha value when animation ends</param>
   /// <returns></returns>
   virtual public  void SetAlpha( double from_alpha,  double to_alpha) {
                                           Efl.Canvas.AnimationAlphaNativeInherit.efl_animation_alpha_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from_alpha,  to_alpha);
      Eina.Error.RaiseIfUnhandledException();
                               }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationAlpha.efl_canvas_animation_alpha_class_get();
   }
}
public class AnimationAlphaNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_animation_alpha_get_static_delegate == null)
      efl_animation_alpha_get_static_delegate = new efl_animation_alpha_get_delegate(alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_alpha_get_static_delegate)});
      if (efl_animation_alpha_set_static_delegate == null)
      efl_animation_alpha_set_static_delegate = new efl_animation_alpha_set_delegate(alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_alpha_set_static_delegate)});
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


    public delegate  void efl_animation_alpha_get_api_delegate(System.IntPtr obj,   out double from_alpha,   out double to_alpha);
    public static Efl.Eo.FunctionWrapper<efl_animation_alpha_get_api_delegate> efl_animation_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_alpha_get_api_delegate>(_Module, "efl_animation_alpha_get");
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
         efl_animation_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_alpha,  out to_alpha);
      }
   }
   private static efl_animation_alpha_get_delegate efl_animation_alpha_get_static_delegate;


    private delegate  void efl_animation_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_alpha,   double to_alpha);


    public delegate  void efl_animation_alpha_set_api_delegate(System.IntPtr obj,   double from_alpha,   double to_alpha);
    public static Efl.Eo.FunctionWrapper<efl_animation_alpha_set_api_delegate> efl_animation_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_alpha_set_api_delegate>(_Module, "efl_animation_alpha_set");
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
         efl_animation_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_alpha,  to_alpha);
      }
   }
   private static efl_animation_alpha_set_delegate efl_animation_alpha_set_static_delegate;
}
} } 
