#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl translate animation class</summary>
[AnimationTranslateNativeInherit]
public class AnimationTranslate : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationTranslateNativeInherit nativeInherit = new Efl.Canvas.AnimationTranslateNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationTranslate))
            return Efl.Canvas.AnimationTranslateNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AnimationTranslate obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_translate_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AnimationTranslate(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AnimationTranslate", efl_canvas_animation_translate_class_get(), typeof(AnimationTranslate), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AnimationTranslate(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimationTranslate(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationTranslate static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationTranslate(obj.NativeHandle);
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
    protected static extern  void efl_animation_translate_get(System.IntPtr obj,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
   /// <summary>Translate property</summary>
   /// <param name="from_x">Distance moved along x axis when animation starts</param>
   /// <param name="from_y">Distance moved along y axis when animation starts</param>
   /// <param name="to_x">Distance moved along x axis when animation ends</param>
   /// <param name="to_y">Distance moved along y axis when animation ends</param>
   /// <returns></returns>
   virtual public  void GetTranslate( out  int from_x,  out  int from_y,  out  int to_x,  out  int to_y) {
                                                                               efl_animation_translate_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_x,  out from_y,  out to_x,  out to_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_translate_set(System.IntPtr obj,    int from_x,    int from_y,    int to_x,    int to_y);
   /// <summary>Translate property</summary>
   /// <param name="from_x">Distance moved along x axis when animation starts</param>
   /// <param name="from_y">Distance moved along y axis when animation starts</param>
   /// <param name="to_x">Distance moved along x axis when animation ends</param>
   /// <param name="to_y">Distance moved along y axis when animation ends</param>
   /// <returns></returns>
   virtual public  void SetTranslate(  int from_x,   int from_y,   int to_x,   int to_y) {
                                                                               efl_animation_translate_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_x,  from_y,  to_x,  to_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_translate_absolute_get(System.IntPtr obj,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
   /// <summary>Translate absolute property</summary>
   /// <param name="from_x">X coordinate when animation starts</param>
   /// <param name="from_y">Y coordinate when animation starts</param>
   /// <param name="to_x">X coordinate when animation ends</param>
   /// <param name="to_y">Y coordinate when animation ends</param>
   /// <returns></returns>
   virtual public  void GetTranslateAbsolute( out  int from_x,  out  int from_y,  out  int to_x,  out  int to_y) {
                                                                               efl_animation_translate_absolute_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out from_x,  out from_y,  out to_x,  out to_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_translate_absolute_set(System.IntPtr obj,    int from_x,    int from_y,    int to_x,    int to_y);
   /// <summary>Translate absolute property</summary>
   /// <param name="from_x">X coordinate when animation starts</param>
   /// <param name="from_y">Y coordinate when animation starts</param>
   /// <param name="to_x">X coordinate when animation ends</param>
   /// <param name="to_y">Y coordinate when animation ends</param>
   /// <returns></returns>
   virtual public  void SetTranslateAbsolute(  int from_x,   int from_y,   int to_x,   int to_y) {
                                                                               efl_animation_translate_absolute_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  from_x,  from_y,  to_x,  to_y);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
}
public class AnimationTranslateNativeInherit : Efl.Canvas.AnimationNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_translate_get_static_delegate = new efl_animation_translate_get_delegate(translate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_translate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_get_static_delegate)});
      efl_animation_translate_set_static_delegate = new efl_animation_translate_set_delegate(translate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_translate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_set_static_delegate)});
      efl_animation_translate_absolute_get_static_delegate = new efl_animation_translate_absolute_get_delegate(translate_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_translate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_absolute_get_static_delegate)});
      efl_animation_translate_absolute_set_static_delegate = new efl_animation_translate_absolute_set_delegate(translate_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_translate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_absolute_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationTranslate.efl_canvas_animation_translate_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationTranslate.efl_canvas_animation_translate_class_get();
   }


    private delegate  void efl_animation_translate_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_translate_get(System.IntPtr obj,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
    private static  void translate_get(System.IntPtr obj, System.IntPtr pd,  out  int from_x,  out  int from_y,  out  int to_x,  out  int to_y)
   {
      Eina.Log.Debug("function efl_animation_translate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       from_x = default( int);      from_y = default( int);      to_x = default( int);      to_y = default( int);                                 
         try {
            ((AnimationTranslate)wrapper).GetTranslate( out from_x,  out from_y,  out to_x,  out to_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_translate_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_x,  out from_y,  out to_x,  out to_y);
      }
   }
   private efl_animation_translate_get_delegate efl_animation_translate_get_static_delegate;


    private delegate  void efl_animation_translate_set_delegate(System.IntPtr obj, System.IntPtr pd,    int from_x,    int from_y,    int to_x,    int to_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_translate_set(System.IntPtr obj,    int from_x,    int from_y,    int to_x,    int to_y);
    private static  void translate_set(System.IntPtr obj, System.IntPtr pd,   int from_x,   int from_y,   int to_x,   int to_y)
   {
      Eina.Log.Debug("function efl_animation_translate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((AnimationTranslate)wrapper).SetTranslate( from_x,  from_y,  to_x,  to_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_translate_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_x,  from_y,  to_x,  to_y);
      }
   }
   private efl_animation_translate_set_delegate efl_animation_translate_set_static_delegate;


    private delegate  void efl_animation_translate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_translate_absolute_get(System.IntPtr obj,   out  int from_x,   out  int from_y,   out  int to_x,   out  int to_y);
    private static  void translate_absolute_get(System.IntPtr obj, System.IntPtr pd,  out  int from_x,  out  int from_y,  out  int to_x,  out  int to_y)
   {
      Eina.Log.Debug("function efl_animation_translate_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       from_x = default( int);      from_y = default( int);      to_x = default( int);      to_y = default( int);                                 
         try {
            ((AnimationTranslate)wrapper).GetTranslateAbsolute( out from_x,  out from_y,  out to_x,  out to_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_translate_absolute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_x,  out from_y,  out to_x,  out to_y);
      }
   }
   private efl_animation_translate_absolute_get_delegate efl_animation_translate_absolute_get_static_delegate;


    private delegate  void efl_animation_translate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,    int from_x,    int from_y,    int to_x,    int to_y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_translate_absolute_set(System.IntPtr obj,    int from_x,    int from_y,    int to_x,    int to_y);
    private static  void translate_absolute_set(System.IntPtr obj, System.IntPtr pd,   int from_x,   int from_y,   int to_x,   int to_y)
   {
      Eina.Log.Debug("function efl_animation_translate_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((AnimationTranslate)wrapper).SetTranslateAbsolute( from_x,  from_y,  to_x,  to_y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_animation_translate_absolute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_x,  from_y,  to_x,  to_y);
      }
   }
   private efl_animation_translate_absolute_set_delegate efl_animation_translate_absolute_set_static_delegate;
}
} } 
