#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl frame controller of frame based animated object interface.</summary>
[FrameControllerNativeInherit]
public interface FrameController : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Check if an object can be animated (has multiple frames).
/// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.
/// 1.1</summary>
/// <returns><c>true</c> if the object is animated</returns>
bool GetAnimated();
   /// <summary>Index of the current frame of an animated object.
/// Ranges from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.FrameController.GetAnimated"/>.</summary>
/// <returns>The index of current frame.</returns>
 int GetFrame();
   /// <summary>Set the frame to current frame of an animated object.
/// 1.1</summary>
/// <param name="frame_index">The index of current frame.</param>
/// <returns>Returns <c>true</c> if the frame index is valid.</returns>
bool SetFrame(  int frame_index);
   /// <summary>Get the total number of frames of the object, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
/// <returns>The number of frames in the animated object.</returns>
 int GetFrameCount();
   /// <summary>Get the kind of looping the animated object does.
/// This returns the kind of looping the animated object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.
/// 1.1</summary>
/// <returns>Loop type of the animated object.</returns>
Efl.Gfx.FrameControllerLoopHint GetLoopType();
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
/// <returns>The number of loop of an animated object.</returns>
 int GetLoopCount();
   /// <summary>Get the duration of a sequence of frames.
/// This returns total duration in seconds that the specified sequence of frames should take.
/// 
/// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.
/// 1.1</summary>
/// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>.</param>
/// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
/// <returns>Duration in seconds</returns>
double GetFrameDuration(  int start_frame,   int frame_num);
                        /// <summary>Check if an object can be animated (has multiple frames).
/// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.
/// 1.1</summary>
/// <value><c>true</c> if the object is animated</value>
   bool Animated {
      get ;
   }
   /// <summary>Index of the current frame of an animated object.
/// Ranges from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.FrameController.GetAnimated"/>.</summary>
/// <value>The index of current frame.</value>
    int Frame {
      get ;
      set ;
   }
   /// <summary>Get the total number of frames of the object, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
/// <value>The number of frames in the animated object.</value>
    int FrameCount {
      get ;
   }
   /// <summary>Get the kind of looping the animated object does.
/// This returns the kind of looping the animated object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.
/// 1.1</summary>
/// <value>Loop type of the animated object.</value>
   Efl.Gfx.FrameControllerLoopHint LoopType {
      get ;
   }
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
/// <value>The number of loop of an animated object.</value>
    int LoopCount {
      get ;
   }
}
/// <summary>Efl frame controller of frame based animated object interface.</summary>
sealed public class FrameControllerConcrete : 

FrameController
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (FrameControllerConcrete))
            return Efl.Gfx.FrameControllerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_frame_controller_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public FrameControllerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~FrameControllerConcrete()
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
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static FrameControllerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new FrameControllerConcrete(obj.NativeHandle);
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
   /// <summary>Check if an object can be animated (has multiple frames).
   /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.
   /// 1.1</summary>
   /// <returns><c>true</c> if the object is animated</returns>
   public bool GetAnimated() {
       var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_animated_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Index of the current frame of an animated object.
   /// Ranges from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.FrameController.GetAnimated"/>.</summary>
   /// <returns>The index of current frame.</returns>
   public  int GetFrame() {
       var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_frame_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the frame to current frame of an animated object.
   /// 1.1</summary>
   /// <param name="frame_index">The index of current frame.</param>
   /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
   public bool SetFrame(  int frame_index) {
                         var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_frame_set_ptr.Value.Delegate(this.NativeHandle, frame_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the total number of frames of the object, if animated.
   /// Returns -1 if not animated.
   /// 1.1</summary>
   /// <returns>The number of frames in the animated object.</returns>
   public  int GetFrameCount() {
       var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the kind of looping the animated object does.
   /// This returns the kind of looping the animated object wants to do.
   /// 
   /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
   /// 
   /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.
   /// 1.1</summary>
   /// <returns>Loop type of the animated object.</returns>
   public Efl.Gfx.FrameControllerLoopHint GetLoopType() {
       var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the number times the animation of the object loops.
   /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
   /// 
   /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
   /// 1.1</summary>
   /// <returns>The number of loop of an animated object.</returns>
   public  int GetLoopCount() {
       var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the duration of a sequence of frames.
   /// This returns total duration in seconds that the specified sequence of frames should take.
   /// 
   /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.
   /// 1.1</summary>
   /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>.</param>
   /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
   /// <returns>Duration in seconds</returns>
   public double GetFrameDuration(  int start_frame,   int frame_num) {
                                           var _ret_var = Efl.Gfx.FrameControllerNativeInherit.efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate(this.NativeHandle, start_frame,  frame_num);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Check if an object can be animated (has multiple frames).
/// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.
/// 1.1</summary>
/// <value><c>true</c> if the object is animated</value>
   public bool Animated {
      get { return GetAnimated(); }
   }
   /// <summary>Index of the current frame of an animated object.
/// Ranges from 1 to <see cref="Efl.Gfx.FrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.FrameController.GetAnimated"/>.</summary>
/// <value>The index of current frame.</value>
   public  int Frame {
      get { return GetFrame(); }
      set { SetFrame( value); }
   }
   /// <summary>Get the total number of frames of the object, if animated.
/// Returns -1 if not animated.
/// 1.1</summary>
/// <value>The number of frames in the animated object.</value>
   public  int FrameCount {
      get { return GetFrameCount(); }
   }
   /// <summary>Get the kind of looping the animated object does.
/// This returns the kind of looping the animated object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.
/// 1.1</summary>
/// <value>Loop type of the animated object.</value>
   public Efl.Gfx.FrameControllerLoopHint LoopType {
      get { return GetLoopType(); }
   }
   /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).
/// 1.1</summary>
/// <value>The number of loop of an animated object.</value>
   public  int LoopCount {
      get { return GetLoopCount(); }
   }
}
public class FrameControllerNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_frame_controller_animated_get_static_delegate == null)
      efl_gfx_frame_controller_animated_get_static_delegate = new efl_gfx_frame_controller_animated_get_delegate(animated_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_animated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_animated_get_static_delegate)});
      if (efl_gfx_frame_controller_frame_get_static_delegate == null)
      efl_gfx_frame_controller_frame_get_static_delegate = new efl_gfx_frame_controller_frame_get_delegate(frame_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_get_static_delegate)});
      if (efl_gfx_frame_controller_frame_set_static_delegate == null)
      efl_gfx_frame_controller_frame_set_static_delegate = new efl_gfx_frame_controller_frame_set_delegate(frame_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_set_static_delegate)});
      if (efl_gfx_frame_controller_frame_count_get_static_delegate == null)
      efl_gfx_frame_controller_frame_count_get_static_delegate = new efl_gfx_frame_controller_frame_count_get_delegate(frame_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_count_get_static_delegate)});
      if (efl_gfx_frame_controller_loop_type_get_static_delegate == null)
      efl_gfx_frame_controller_loop_type_get_static_delegate = new efl_gfx_frame_controller_loop_type_get_delegate(loop_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_loop_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_type_get_static_delegate)});
      if (efl_gfx_frame_controller_loop_count_get_static_delegate == null)
      efl_gfx_frame_controller_loop_count_get_static_delegate = new efl_gfx_frame_controller_loop_count_get_delegate(loop_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_loop_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_count_get_static_delegate)});
      if (efl_gfx_frame_controller_frame_duration_get_static_delegate == null)
      efl_gfx_frame_controller_frame_duration_get_static_delegate = new efl_gfx_frame_controller_frame_duration_get_delegate(frame_duration_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_frame_controller_frame_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_duration_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.FrameControllerConcrete.efl_gfx_frame_controller_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.FrameControllerConcrete.efl_gfx_frame_controller_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_frame_controller_animated_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_frame_controller_animated_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate> efl_gfx_frame_controller_animated_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate>(_Module, "efl_gfx_frame_controller_animated_get");
    private static bool animated_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_animated_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((FrameController)wrapper).GetAnimated();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_frame_controller_animated_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_frame_controller_animated_get_delegate efl_gfx_frame_controller_animated_get_static_delegate;


    private delegate  int efl_gfx_frame_controller_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_gfx_frame_controller_frame_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate> efl_gfx_frame_controller_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate>(_Module, "efl_gfx_frame_controller_frame_get");
    private static  int frame_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_frame_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((FrameController)wrapper).GetFrame();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_frame_controller_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_frame_controller_frame_get_delegate efl_gfx_frame_controller_frame_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_frame_controller_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,    int frame_index);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_frame_controller_frame_set_api_delegate(System.IntPtr obj,    int frame_index);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate> efl_gfx_frame_controller_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate>(_Module, "efl_gfx_frame_controller_frame_set");
    private static bool frame_set(System.IntPtr obj, System.IntPtr pd,   int frame_index)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_frame_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((FrameController)wrapper).SetFrame( frame_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_frame_controller_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  frame_index);
      }
   }
   private static efl_gfx_frame_controller_frame_set_delegate efl_gfx_frame_controller_frame_set_static_delegate;


    private delegate  int efl_gfx_frame_controller_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_gfx_frame_controller_frame_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate> efl_gfx_frame_controller_frame_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate>(_Module, "efl_gfx_frame_controller_frame_count_get");
    private static  int frame_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_frame_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((FrameController)wrapper).GetFrameCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_frame_controller_frame_count_get_delegate efl_gfx_frame_controller_frame_count_get_static_delegate;


    private delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate> efl_gfx_frame_controller_loop_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate>(_Module, "efl_gfx_frame_controller_loop_type_get");
    private static Efl.Gfx.FrameControllerLoopHint loop_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_loop_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.FrameControllerLoopHint _ret_var = default(Efl.Gfx.FrameControllerLoopHint);
         try {
            _ret_var = ((FrameController)wrapper).GetLoopType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_frame_controller_loop_type_get_delegate efl_gfx_frame_controller_loop_type_get_static_delegate;


    private delegate  int efl_gfx_frame_controller_loop_count_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_gfx_frame_controller_loop_count_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate> efl_gfx_frame_controller_loop_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate>(_Module, "efl_gfx_frame_controller_loop_count_get");
    private static  int loop_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_loop_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((FrameController)wrapper).GetLoopCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_frame_controller_loop_count_get_delegate efl_gfx_frame_controller_loop_count_get_static_delegate;


    private delegate double efl_gfx_frame_controller_frame_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,    int start_frame,    int frame_num);


    public delegate double efl_gfx_frame_controller_frame_duration_get_api_delegate(System.IntPtr obj,    int start_frame,    int frame_num);
    public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate> efl_gfx_frame_controller_frame_duration_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate>(_Module, "efl_gfx_frame_controller_frame_duration_get");
    private static double frame_duration_get(System.IntPtr obj, System.IntPtr pd,   int start_frame,   int frame_num)
   {
      Eina.Log.Debug("function efl_gfx_frame_controller_frame_duration_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      double _ret_var = default(double);
         try {
            _ret_var = ((FrameController)wrapper).GetFrameDuration( start_frame,  frame_num);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  start_frame,  frame_num);
      }
   }
   private static efl_gfx_frame_controller_frame_duration_get_delegate efl_gfx_frame_controller_frame_duration_get_static_delegate;
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Frame loop modes</summary>
public enum FrameControllerLoopHint
{
/// <summary>No looping order specified.</summary>
None = 0,
/// <summary>Standard loop: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Loop = 1,
/// <summary>Ping-pong bouncing loop: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Pingpong = 2,
}
} } 
