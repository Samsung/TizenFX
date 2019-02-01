#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl animated image interface</summary>
[ImageAnimationControllerConcreteNativeInherit]
public interface ImageAnimationController : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Check if an image can be animated (has multiple frames).
/// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
/// 1.1</summary>
/// <returns><c>true</c> if the image is animated</returns>
bool GetAnimated();
   /// <summary>Index of the current frame of an animated image.
/// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
/// <returns>The index of current frame.</returns>
 int GetAnimatedFrame();
   /// <summary>Set the frame to current frame of an image object.
/// 1.1</summary>
/// <param name="frame_index">The index of current frame.</param>
/// <returns>Returns <c>true</c> if the frame index is valid.</returns>
bool SetAnimatedFrame(  int frame_index);
   /// <summary>Get the total number of frames of the image, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
/// <returns>The number of frames in the animated image.</returns>
 int GetAnimatedFrameCount();
   /// <summary>Get the kind of looping the image object does.
/// This returns the kind of looping the image object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
/// 1.1</summary>
/// <returns>Loop type of the image object.</returns>
Efl.Gfx.ImageAnimationControllerLoopHint GetAnimatedLoopType();
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
/// <returns>The number of loop of an animated image object.</returns>
 int GetAnimatedLoopCount();
   /// <summary>Get the duration of a sequence of frames.
/// This returns total duration in seconds that the specified sequence of frames should take.
/// 
/// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.
/// 1.1</summary>
/// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>.</param>
/// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
/// <returns>Duration in seconds</returns>
double GetAnimatedFrameDuration(  int start_frame,   int frame_num);
                        /// <summary>Check if an image can be animated (has multiple frames).
/// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
/// 1.1</summary>
   bool Animated {
      get ;
   }
   /// <summary>Index of the current frame of an animated image.
/// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
    int AnimatedFrame {
      get ;
      set ;
   }
   /// <summary>Get the total number of frames of the image, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
    int AnimatedFrameCount {
      get ;
   }
   /// <summary>Get the kind of looping the image object does.
/// This returns the kind of looping the image object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
/// 1.1</summary>
   Efl.Gfx.ImageAnimationControllerLoopHint AnimatedLoopType {
      get ;
   }
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
    int AnimatedLoopCount {
      get ;
   }
}
/// <summary>Efl animated image interface</summary>
sealed public class ImageAnimationControllerConcrete : 

ImageAnimationController
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ImageAnimationControllerConcrete))
            return Efl.Gfx.ImageAnimationControllerConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_image_animation_controller_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ImageAnimationControllerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ImageAnimationControllerConcrete()
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
   public static ImageAnimationControllerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ImageAnimationControllerConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_get(System.IntPtr obj);
   /// <summary>Check if an image can be animated (has multiple frames).
   /// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
   /// 1.1</summary>
   /// <returns><c>true</c> if the image is animated</returns>
   public bool GetAnimated() {
       var _ret_var = efl_gfx_image_animated_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_gfx_image_animated_frame_get(System.IntPtr obj);
   /// <summary>Index of the current frame of an animated image.
   /// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
   /// <returns>The index of current frame.</returns>
   public  int GetAnimatedFrame() {
       var _ret_var = efl_gfx_image_animated_frame_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_frame_set(System.IntPtr obj,    int frame_index);
   /// <summary>Set the frame to current frame of an image object.
   /// 1.1</summary>
   /// <param name="frame_index">The index of current frame.</param>
   /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
   public bool SetAnimatedFrame(  int frame_index) {
                         var _ret_var = efl_gfx_image_animated_frame_set(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get(),  frame_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_gfx_image_animated_frame_count_get(System.IntPtr obj);
   /// <summary>Get the total number of frames of the image, if animated.
   /// Returns -1 if not animated.
   /// 1.1</summary>
   /// <returns>The number of frames in the animated image.</returns>
   public  int GetAnimatedFrameCount() {
       var _ret_var = efl_gfx_image_animated_frame_count_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get(System.IntPtr obj);
   /// <summary>Get the kind of looping the image object does.
   /// This returns the kind of looping the image object wants to do.
   /// 
   /// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
   /// 1.1</summary>
   /// <returns>Loop type of the image object.</returns>
   public Efl.Gfx.ImageAnimationControllerLoopHint GetAnimatedLoopType() {
       var _ret_var = efl_gfx_image_animated_loop_type_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_gfx_image_animated_loop_count_get(System.IntPtr obj);
   /// <summary>Get the number times the animation of the object loops.
   /// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
   /// 
   /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
   /// 1.1</summary>
   /// <returns>The number of loop of an animated image object.</returns>
   public  int GetAnimatedLoopCount() {
       var _ret_var = efl_gfx_image_animated_loop_count_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_gfx_image_animated_frame_duration_get(System.IntPtr obj,    int start_frame,    int frame_num);
   /// <summary>Get the duration of a sequence of frames.
   /// This returns total duration in seconds that the specified sequence of frames should take.
   /// 
   /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.
   /// 1.1</summary>
   /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>.</param>
   /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
   /// <returns>Duration in seconds</returns>
   public double GetAnimatedFrameDuration(  int start_frame,   int frame_num) {
                                           var _ret_var = efl_gfx_image_animated_frame_duration_get(Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get(),  start_frame,  frame_num);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Check if an image can be animated (has multiple frames).
/// This will be <c>true</c> for animated Gif files for instance but <c>false</c> for still images.
/// 1.1</summary>
   public bool Animated {
      get { return GetAnimated(); }
   }
   /// <summary>Index of the current frame of an animated image.
/// Ranges from 1 to <see cref="Efl.Gfx.ImageAnimationController.GetAnimatedFrameCount"/>. Valid only if <see cref="Efl.Gfx.ImageAnimationController.GetAnimated"/>.</summary>
   public  int AnimatedFrame {
      get { return GetAnimatedFrame(); }
      set { SetAnimatedFrame( value); }
   }
   /// <summary>Get the total number of frames of the image, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
   public  int AnimatedFrameCount {
      get { return GetAnimatedFrameCount(); }
   }
   /// <summary>Get the kind of looping the image object does.
/// This returns the kind of looping the image object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.ImageAnimationControllerLoopHint.Loop"/>.
/// 1.1</summary>
   public Efl.Gfx.ImageAnimationControllerLoopHint AnimatedLoopType {
      get { return GetAnimatedLoopType(); }
   }
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of image. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
   public  int AnimatedLoopCount {
      get { return GetAnimatedLoopCount(); }
   }
}
public class ImageAnimationControllerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_image_animated_get_static_delegate = new efl_gfx_image_animated_get_delegate(animated_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_get_static_delegate)});
      efl_gfx_image_animated_frame_get_static_delegate = new efl_gfx_image_animated_frame_get_delegate(animated_frame_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_get_static_delegate)});
      efl_gfx_image_animated_frame_set_static_delegate = new efl_gfx_image_animated_frame_set_delegate(animated_frame_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_set_static_delegate)});
      efl_gfx_image_animated_frame_count_get_static_delegate = new efl_gfx_image_animated_frame_count_get_delegate(animated_frame_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_count_get_static_delegate)});
      efl_gfx_image_animated_loop_type_get_static_delegate = new efl_gfx_image_animated_loop_type_get_delegate(animated_loop_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_loop_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_loop_type_get_static_delegate)});
      efl_gfx_image_animated_loop_count_get_static_delegate = new efl_gfx_image_animated_loop_count_get_delegate(animated_loop_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_loop_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_loop_count_get_static_delegate)});
      efl_gfx_image_animated_frame_duration_get_static_delegate = new efl_gfx_image_animated_frame_duration_get_delegate(animated_frame_duration_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_image_animated_frame_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_animated_frame_duration_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ImageAnimationControllerConcrete.efl_gfx_image_animation_controller_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_animated_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_get(System.IntPtr obj);
    private static bool animated_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimated();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_get_delegate efl_gfx_image_animated_get_static_delegate;


    private delegate  int efl_gfx_image_animated_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_frame_get(System.IntPtr obj);
    private static  int animated_frame_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimatedFrame();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_frame_get_delegate efl_gfx_image_animated_frame_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_animated_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,    int frame_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_image_animated_frame_set(System.IntPtr obj,    int frame_index);
    private static bool animated_frame_set(System.IntPtr obj, System.IntPtr pd,   int frame_index)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ImageAnimationController)wrapper).SetAnimatedFrame( frame_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  frame_index);
      }
   }
   private efl_gfx_image_animated_frame_set_delegate efl_gfx_image_animated_frame_set_static_delegate;


    private delegate  int efl_gfx_image_animated_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_frame_count_get(System.IntPtr obj);
    private static  int animated_frame_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimatedFrameCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_frame_count_get_delegate efl_gfx_image_animated_frame_count_get_static_delegate;


    private delegate Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.ImageAnimationControllerLoopHint efl_gfx_image_animated_loop_type_get(System.IntPtr obj);
    private static Efl.Gfx.ImageAnimationControllerLoopHint animated_loop_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_loop_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.ImageAnimationControllerLoopHint _ret_var = default(Efl.Gfx.ImageAnimationControllerLoopHint);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimatedLoopType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_loop_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_loop_type_get_delegate efl_gfx_image_animated_loop_type_get_static_delegate;


    private delegate  int efl_gfx_image_animated_loop_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_image_animated_loop_count_get(System.IntPtr obj);
    private static  int animated_loop_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_loop_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimatedLoopCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_image_animated_loop_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_image_animated_loop_count_get_delegate efl_gfx_image_animated_loop_count_get_static_delegate;


    private delegate double efl_gfx_image_animated_frame_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,    int start_frame,    int frame_num);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_image_animated_frame_duration_get(System.IntPtr obj,    int start_frame,    int frame_num);
    private static double animated_frame_duration_get(System.IntPtr obj, System.IntPtr pd,   int start_frame,   int frame_num)
   {
      Eina.Log.Debug("function efl_gfx_image_animated_frame_duration_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      double _ret_var = default(double);
         try {
            _ret_var = ((ImageAnimationController)wrapper).GetAnimatedFrameDuration( start_frame,  frame_num);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_gfx_image_animated_frame_duration_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_frame,  frame_num);
      }
   }
   private efl_gfx_image_animated_frame_duration_get_delegate efl_gfx_image_animated_frame_duration_get_static_delegate;
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Image animation loop modes</summary>
public enum ImageAnimationControllerLoopHint
{
/// <summary>No looping order specified.</summary>
None = 0,
/// <summary>Standard loop: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Loop = 1,
/// <summary>Ping-pong bouncing loop: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Pingpong = 2,
}
} } 
