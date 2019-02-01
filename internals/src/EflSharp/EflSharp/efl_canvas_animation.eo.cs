#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl animation class</summary>
[AnimationNativeInherit]
public class Animation : Efl.Object, Efl.Eo.IWrapper,Efl.Playable
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationNativeInherit nativeInherit = new Efl.Canvas.AnimationNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Animation))
            return Efl.Canvas.AnimationNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Animation obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Animation(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Animation", efl_canvas_animation_class_get(), typeof(Animation), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Animation(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Animation(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Animation static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Animation(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_animation_final_state_keep_get(System.IntPtr obj);
   /// <summary>Keep final state property</summary>
   /// <returns><c>true</c> to keep final state, <c>false</c> otherwise.</returns>
   virtual public bool GetFinalStateKeep() {
       var _ret_var = efl_animation_final_state_keep_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_final_state_keep_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool keep);
   /// <summary>Keep final state property</summary>
   /// <param name="keep"><c>true</c> to keep final state, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetFinalStateKeep( bool keep) {
                         efl_animation_final_state_keep_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  keep);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern double efl_animation_duration_get(System.IntPtr obj);
   /// <summary>Duration property</summary>
   /// <returns>Duration value.</returns>
   virtual public double GetDuration() {
       var _ret_var = efl_animation_duration_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_duration_set(System.IntPtr obj,   double sec);
   /// <summary>Duration property</summary>
   /// <param name="sec">Duration value.</param>
   /// <returns></returns>
   virtual public  void SetDuration( double sec) {
                         efl_animation_duration_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sec);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get(System.IntPtr obj);
   /// <summary>Repeat mode property</summary>
   /// <returns>Repeat mode. EFL_ANIMATION_REPEAT_MODE_RESTART restarts animation when the animation ends and EFL_ANIMATION_REPEAT_MODE_REVERSE reverses animation when the animation ends.</returns>
   virtual public Efl.Canvas.AnimationRepeatMode GetRepeatMode() {
       var _ret_var = efl_animation_repeat_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_repeat_mode_set(System.IntPtr obj,   Efl.Canvas.AnimationRepeatMode mode);
   /// <summary>Repeat mode property</summary>
   /// <param name="mode">Repeat mode. EFL_ANIMATION_REPEAT_MODE_RESTART restarts animation when the animation ends and EFL_ANIMATION_REPEAT_MODE_REVERSE reverses animation when the animation ends.</param>
   /// <returns></returns>
   virtual public  void SetRepeatMode( Efl.Canvas.AnimationRepeatMode mode) {
                         efl_animation_repeat_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_animation_repeat_count_get(System.IntPtr obj);
   /// <summary>Repeat count property</summary>
   /// <returns>Repeat count. EFL_ANIMATION_REPEAT_INFINITE repeats animation infinitely.</returns>
   virtual public  int GetRepeatCount() {
       var _ret_var = efl_animation_repeat_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_repeat_count_set(System.IntPtr obj,    int count);
   /// <summary>Repeat count property</summary>
   /// <param name="count">Repeat count. EFL_ANIMATION_REPEAT_INFINITE repeats animation infinitely.</param>
   /// <returns></returns>
   virtual public  void SetRepeatCount(  int count) {
                         efl_animation_repeat_count_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  count);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern double efl_animation_start_delay_get(System.IntPtr obj);
   /// <summary>Start delay property</summary>
   /// <returns>Delay time, in seconds, from when the animation starts until the animation is animated</returns>
   virtual public double GetStartDelay() {
       var _ret_var = efl_animation_start_delay_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_start_delay_set(System.IntPtr obj,   double sec);
   /// <summary>Start delay property</summary>
   /// <param name="sec">Delay time, in seconds, from when the animation starts until the animation is animated</param>
   /// <returns></returns>
   virtual public  void SetStartDelay( double sec) {
                         efl_animation_start_delay_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sec);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Interpolator efl_animation_interpolator_get(System.IntPtr obj);
   /// <summary>Interpolator property</summary>
   /// <returns>Interpolator which indicates interpolation fucntion. Efl_Interpolator is required.</returns>
   virtual public Efl.Interpolator GetInterpolator() {
       var _ret_var = efl_animation_interpolator_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_interpolator_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))]  Efl.Interpolator interpolator);
   /// <summary>Interpolator property</summary>
   /// <param name="interpolator">Interpolator which indicates interpolation fucntion. Efl_Interpolator is required.</param>
   /// <returns></returns>
   virtual public  void SetInterpolator( Efl.Interpolator interpolator) {
                         efl_animation_interpolator_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  interpolator);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern double efl_animation_apply(System.IntPtr obj,   double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
   /// <summary></summary>
   /// <param name="progress"></param>
   /// <param name="target"></param>
   /// <returns>Final applied progress.</returns>
   virtual public double AnimationApply( double progress,  Efl.Canvas.Object target) {
                                           var _ret_var = efl_animation_apply((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  progress,  target);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_playable_length_get(System.IntPtr obj);
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   virtual public double GetLength() {
       var _ret_var = efl_playable_length_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_playable_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   virtual public bool GetPlayable() {
       var _ret_var = efl_playable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_playable_seekable_get(System.IntPtr obj);
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   virtual public bool GetSeekable() {
       var _ret_var = efl_playable_seekable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Keep final state property</summary>
   public bool FinalStateKeep {
      get { return GetFinalStateKeep(); }
      set { SetFinalStateKeep( value); }
   }
   /// <summary>Duration property</summary>
   public double Duration {
      get { return GetDuration(); }
      set { SetDuration( value); }
   }
   /// <summary>Repeat mode property</summary>
   public Efl.Canvas.AnimationRepeatMode RepeatMode {
      get { return GetRepeatMode(); }
      set { SetRepeatMode( value); }
   }
   /// <summary>Repeat count property</summary>
   public  int RepeatCount {
      get { return GetRepeatCount(); }
      set { SetRepeatCount( value); }
   }
   /// <summary>Start delay property</summary>
   public double StartDelay {
      get { return GetStartDelay(); }
      set { SetStartDelay( value); }
   }
   /// <summary>Interpolator property</summary>
   public Efl.Interpolator Interpolator {
      get { return GetInterpolator(); }
      set { SetInterpolator( value); }
   }
   /// <summary>Get the length of play for the media file.</summary>
   public double Length {
      get { return GetLength(); }
   }
   /// <summary></summary>
   public bool Playable {
      get { return GetPlayable(); }
   }
   /// <summary>Get whether the media file is seekable.</summary>
   public bool Seekable {
      get { return GetSeekable(); }
   }
}
public class AnimationNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_final_state_keep_get_static_delegate = new efl_animation_final_state_keep_get_delegate(final_state_keep_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_final_state_keep_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_get_static_delegate)});
      efl_animation_final_state_keep_set_static_delegate = new efl_animation_final_state_keep_set_delegate(final_state_keep_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_final_state_keep_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_set_static_delegate)});
      efl_animation_duration_get_static_delegate = new efl_animation_duration_get_delegate(duration_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_get_static_delegate)});
      efl_animation_duration_set_static_delegate = new efl_animation_duration_set_delegate(duration_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_duration_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_set_static_delegate)});
      efl_animation_repeat_mode_get_static_delegate = new efl_animation_repeat_mode_get_delegate(repeat_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_repeat_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_get_static_delegate)});
      efl_animation_repeat_mode_set_static_delegate = new efl_animation_repeat_mode_set_delegate(repeat_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_repeat_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_set_static_delegate)});
      efl_animation_repeat_count_get_static_delegate = new efl_animation_repeat_count_get_delegate(repeat_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_repeat_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_count_get_static_delegate)});
      efl_animation_repeat_count_set_static_delegate = new efl_animation_repeat_count_set_delegate(repeat_count_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_repeat_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_count_set_static_delegate)});
      efl_animation_start_delay_get_static_delegate = new efl_animation_start_delay_get_delegate(start_delay_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_start_delay_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_get_static_delegate)});
      efl_animation_start_delay_set_static_delegate = new efl_animation_start_delay_set_delegate(start_delay_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_start_delay_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_set_static_delegate)});
      efl_animation_interpolator_get_static_delegate = new efl_animation_interpolator_get_delegate(interpolator_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_interpolator_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_get_static_delegate)});
      efl_animation_interpolator_set_static_delegate = new efl_animation_interpolator_set_delegate(interpolator_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_interpolator_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_set_static_delegate)});
      efl_animation_apply_static_delegate = new efl_animation_apply_delegate(animation_apply);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_apply_static_delegate)});
      efl_playable_length_get_static_delegate = new efl_playable_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_playable_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_length_get_static_delegate)});
      efl_playable_get_static_delegate = new efl_playable_get_delegate(playable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_get_static_delegate)});
      efl_playable_seekable_get_static_delegate = new efl_playable_seekable_get_delegate(seekable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_playable_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_seekable_get_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Animation.efl_canvas_animation_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Animation.efl_canvas_animation_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_animation_final_state_keep_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_animation_final_state_keep_get(System.IntPtr obj);
    private static bool final_state_keep_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_final_state_keep_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Animation)wrapper).GetFinalStateKeep();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_final_state_keep_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_final_state_keep_get_delegate efl_animation_final_state_keep_get_static_delegate;


    private delegate  void efl_animation_final_state_keep_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool keep);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_final_state_keep_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool keep);
    private static  void final_state_keep_set(System.IntPtr obj, System.IntPtr pd,  bool keep)
   {
      Eina.Log.Debug("function efl_animation_final_state_keep_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetFinalStateKeep( keep);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_final_state_keep_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  keep);
      }
   }
   private efl_animation_final_state_keep_set_delegate efl_animation_final_state_keep_set_static_delegate;


    private delegate double efl_animation_duration_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern double efl_animation_duration_get(System.IntPtr obj);
    private static double duration_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_duration_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Animation)wrapper).GetDuration();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_duration_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_duration_get_delegate efl_animation_duration_get_static_delegate;


    private delegate  void efl_animation_duration_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_duration_set(System.IntPtr obj,   double sec);
    private static  void duration_set(System.IntPtr obj, System.IntPtr pd,  double sec)
   {
      Eina.Log.Debug("function efl_animation_duration_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetDuration( sec);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_duration_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
      }
   }
   private efl_animation_duration_set_delegate efl_animation_duration_set_static_delegate;


    private delegate Efl.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get(System.IntPtr obj);
    private static Efl.Canvas.AnimationRepeatMode repeat_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_repeat_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.AnimationRepeatMode _ret_var = default(Efl.Canvas.AnimationRepeatMode);
         try {
            _ret_var = ((Animation)wrapper).GetRepeatMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_repeat_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_repeat_mode_get_delegate efl_animation_repeat_mode_get_static_delegate;


    private delegate  void efl_animation_repeat_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Canvas.AnimationRepeatMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_repeat_mode_set(System.IntPtr obj,   Efl.Canvas.AnimationRepeatMode mode);
    private static  void repeat_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.AnimationRepeatMode mode)
   {
      Eina.Log.Debug("function efl_animation_repeat_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetRepeatMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_repeat_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_animation_repeat_mode_set_delegate efl_animation_repeat_mode_set_static_delegate;


    private delegate  int efl_animation_repeat_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_animation_repeat_count_get(System.IntPtr obj);
    private static  int repeat_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_repeat_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Animation)wrapper).GetRepeatCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_repeat_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_repeat_count_get_delegate efl_animation_repeat_count_get_static_delegate;


    private delegate  void efl_animation_repeat_count_set_delegate(System.IntPtr obj, System.IntPtr pd,    int count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_repeat_count_set(System.IntPtr obj,    int count);
    private static  void repeat_count_set(System.IntPtr obj, System.IntPtr pd,   int count)
   {
      Eina.Log.Debug("function efl_animation_repeat_count_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetRepeatCount( count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_repeat_count_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  count);
      }
   }
   private efl_animation_repeat_count_set_delegate efl_animation_repeat_count_set_static_delegate;


    private delegate double efl_animation_start_delay_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern double efl_animation_start_delay_get(System.IntPtr obj);
    private static double start_delay_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_start_delay_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Animation)wrapper).GetStartDelay();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_start_delay_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_start_delay_get_delegate efl_animation_start_delay_get_static_delegate;


    private delegate  void efl_animation_start_delay_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_start_delay_set(System.IntPtr obj,   double sec);
    private static  void start_delay_set(System.IntPtr obj, System.IntPtr pd,  double sec)
   {
      Eina.Log.Debug("function efl_animation_start_delay_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetStartDelay( sec);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_start_delay_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
      }
   }
   private efl_animation_start_delay_set_delegate efl_animation_start_delay_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Interpolator efl_animation_interpolator_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Interpolator efl_animation_interpolator_get(System.IntPtr obj);
    private static Efl.Interpolator interpolator_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_interpolator_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Interpolator _ret_var = default(Efl.Interpolator);
         try {
            _ret_var = ((Animation)wrapper).GetInterpolator();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_interpolator_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_interpolator_get_delegate efl_animation_interpolator_get_static_delegate;


    private delegate  void efl_animation_interpolator_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))]  Efl.Interpolator interpolator);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_interpolator_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.InterpolatorConcrete, Efl.Eo.NonOwnTag>))]  Efl.Interpolator interpolator);
    private static  void interpolator_set(System.IntPtr obj, System.IntPtr pd,  Efl.Interpolator interpolator)
   {
      Eina.Log.Debug("function efl_animation_interpolator_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Animation)wrapper).SetInterpolator( interpolator);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_interpolator_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  interpolator);
      }
   }
   private efl_animation_interpolator_set_delegate efl_animation_interpolator_set_static_delegate;


    private delegate double efl_animation_apply_delegate(System.IntPtr obj, System.IntPtr pd,   double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern double efl_animation_apply(System.IntPtr obj,   double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
    private static double animation_apply(System.IntPtr obj, System.IntPtr pd,  double progress,  Efl.Canvas.Object target)
   {
      Eina.Log.Debug("function efl_animation_apply was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      double _ret_var = default(double);
         try {
            _ret_var = ((Animation)wrapper).AnimationApply( progress,  target);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_animation_apply(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  progress,  target);
      }
   }
   private efl_animation_apply_delegate efl_animation_apply_static_delegate;


    private delegate double efl_playable_length_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_playable_length_get(System.IntPtr obj);
    private static double length_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_length_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Animation)wrapper).GetLength();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_length_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_playable_length_get_delegate efl_playable_length_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_playable_get(System.IntPtr obj);
    private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Animation)wrapper).GetPlayable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_playable_get_delegate efl_playable_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_playable_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_playable_seekable_get(System.IntPtr obj);
    private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_seekable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Animation)wrapper).GetSeekable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_seekable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_playable_seekable_get_delegate efl_playable_seekable_get_static_delegate;
}
} } 
