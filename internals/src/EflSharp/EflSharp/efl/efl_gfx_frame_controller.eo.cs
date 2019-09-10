#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Efl frame controller of frame based animated object interface.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.IFrameControllerConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IFrameController : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Check if an object can be animated (has multiple frames).
/// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
/// <returns><c>true</c> if the object is animated</returns>
bool GetAnimated();
    /// <summary>Index of the current frame of an animated object.
/// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
/// <returns>The index of current frame.</returns>
int GetFrame();
    /// <summary>Set the frame to current frame of an animated object.</summary>
/// <param name="frame_index">The index of current frame.</param>
/// <returns>Returns <c>true</c> if the frame index is valid.</returns>
bool SetFrame(int frame_index);
    /// <summary>Get the total number of frames of the object, if animated.
/// Returns -1 if not animated.</summary>
/// <returns>The number of frames in the animated object.</returns>
int GetFrameCount();
    /// <summary>Get the kind of looping the animated object does.
/// This returns the kind of looping the animated object wants to do.
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
/// 
/// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
/// <returns>Loop type of the animated object.</returns>
Efl.Gfx.FrameControllerLoopHint GetLoopType();
    /// <summary>Get the number times the animation of the object loops.
/// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
/// 
/// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
/// <returns>The number of loop of an animated object.</returns>
int GetLoopCount();
    /// <summary>Get the duration of a sequence of frames.
/// This returns total duration in seconds that the specified sequence of frames should take.
/// 
/// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.</summary>
/// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>.</param>
/// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
/// <returns>Duration in seconds</returns>
double GetFrameDuration(int start_frame, int frame_num);
                                /// <summary>Check if an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <value><c>true</c> if the object is animated</value>
    bool Animated {
        get;
    }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
    /// <value>The index of current frame.</value>
    int Frame {
        get;
        set;
    }
    /// <summary>Get the total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <value>The number of frames in the animated object.</value>
    int FrameCount {
        get;
    }
    /// <summary>Get the kind of looping the animated object does.
    /// This returns the kind of looping the animated object wants to do.
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <value>Loop type of the animated object.</value>
    Efl.Gfx.FrameControllerLoopHint LoopType {
        get;
    }
    /// <summary>Get the number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <value>The number of loop of an animated object.</value>
    int LoopCount {
        get;
    }
}
/// <summary>Efl frame controller of frame based animated object interface.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IFrameControllerConcrete :
    Efl.Eo.EoWrapper
    , IFrameController
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFrameControllerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IFrameControllerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_frame_controller_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IFrameController"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IFrameControllerConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Check if an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <returns><c>true</c> if the object is animated</returns>
    public bool GetAnimated() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_animated_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
    /// <returns>The index of current frame.</returns>
    public int GetFrame() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the frame to current frame of an animated object.</summary>
    /// <param name="frame_index">The index of current frame.</param>
    /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
    public bool SetFrame(int frame_index) {
                                 var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_set_ptr.Value.Delegate(this.NativeHandle,frame_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <returns>The number of frames in the animated object.</returns>
    public int GetFrameCount() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate(this.NativeHandle);
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
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <returns>Loop type of the animated object.</returns>
    public Efl.Gfx.FrameControllerLoopHint GetLoopType() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <returns>The number of loop of an animated object.</returns>
    public int GetLoopCount() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the duration of a sequence of frames.
    /// This returns total duration in seconds that the specified sequence of frames should take.
    /// 
    /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.</summary>
    /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>.</param>
    /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
    /// <returns>Duration in seconds</returns>
    public double GetFrameDuration(int start_frame, int frame_num) {
                                                         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate(this.NativeHandle,start_frame, frame_num);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Check if an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <value><c>true</c> if the object is animated</value>
    public bool Animated {
        get { return GetAnimated(); }
    }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
    /// <value>The index of current frame.</value>
    public int Frame {
        get { return GetFrame(); }
        set { SetFrame(value); }
    }
    /// <summary>Get the total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <value>The number of frames in the animated object.</value>
    public int FrameCount {
        get { return GetFrameCount(); }
    }
    /// <summary>Get the kind of looping the animated object does.
    /// This returns the kind of looping the animated object wants to do.
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <value>Loop type of the animated object.</value>
    public Efl.Gfx.FrameControllerLoopHint LoopType {
        get { return GetLoopType(); }
    }
    /// <summary>Get the number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <value>The number of loop of an animated object.</value>
    public int LoopCount {
        get { return GetLoopCount(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IFrameControllerConcrete.efl_gfx_frame_controller_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_frame_controller_animated_get_static_delegate == null)
            {
                efl_gfx_frame_controller_animated_get_static_delegate = new efl_gfx_frame_controller_animated_get_delegate(animated_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnimated") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_animated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_animated_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_get_static_delegate = new efl_gfx_frame_controller_frame_get_delegate(frame_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_set_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_set_static_delegate = new efl_gfx_frame_controller_frame_set_delegate(frame_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_set_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_count_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_count_get_static_delegate = new efl_gfx_frame_controller_frame_count_get_delegate(frame_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrameCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_count_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_loop_type_get_static_delegate == null)
            {
                efl_gfx_frame_controller_loop_type_get_static_delegate = new efl_gfx_frame_controller_loop_type_get_delegate(loop_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoopType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_loop_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_type_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_loop_count_get_static_delegate == null)
            {
                efl_gfx_frame_controller_loop_count_get_static_delegate = new efl_gfx_frame_controller_loop_count_get_delegate(loop_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoopCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_loop_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_count_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_duration_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_duration_get_static_delegate = new efl_gfx_frame_controller_frame_duration_get_delegate(frame_duration_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrameDuration") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_duration_get_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.IFrameControllerConcrete.efl_gfx_frame_controller_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_frame_controller_animated_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_frame_controller_animated_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate> efl_gfx_frame_controller_animated_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate>(Module, "efl_gfx_frame_controller_animated_get");

        private static bool animated_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_animated_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetAnimated();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_animated_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_animated_get_delegate efl_gfx_frame_controller_animated_get_static_delegate;

        
        private delegate int efl_gfx_frame_controller_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_frame_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate> efl_gfx_frame_controller_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_get");

        private static int frame_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetFrame();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_frame_get_delegate efl_gfx_frame_controller_frame_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_frame_controller_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,  int frame_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_frame_controller_frame_set_api_delegate(System.IntPtr obj,  int frame_index);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate> efl_gfx_frame_controller_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate>(Module, "efl_gfx_frame_controller_frame_set");

        private static bool frame_set(System.IntPtr obj, System.IntPtr pd, int frame_index)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).SetFrame(frame_index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), frame_index);
            }
        }

        private static efl_gfx_frame_controller_frame_set_delegate efl_gfx_frame_controller_frame_set_static_delegate;

        
        private delegate int efl_gfx_frame_controller_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_frame_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate> efl_gfx_frame_controller_frame_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_count_get");

        private static int frame_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetFrameCount();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_frame_count_get_delegate efl_gfx_frame_controller_frame_count_get_static_delegate;

        
        private delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate> efl_gfx_frame_controller_loop_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate>(Module, "efl_gfx_frame_controller_loop_type_get");

        private static Efl.Gfx.FrameControllerLoopHint loop_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_loop_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.FrameControllerLoopHint _ret_var = default(Efl.Gfx.FrameControllerLoopHint);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetLoopType();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_loop_type_get_delegate efl_gfx_frame_controller_loop_type_get_static_delegate;

        
        private delegate int efl_gfx_frame_controller_loop_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_loop_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate> efl_gfx_frame_controller_loop_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate>(Module, "efl_gfx_frame_controller_loop_count_get");

        private static int loop_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_loop_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetLoopCount();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_loop_count_get_delegate efl_gfx_frame_controller_loop_count_get_static_delegate;

        
        private delegate double efl_gfx_frame_controller_frame_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,  int start_frame,  int frame_num);

        
        public delegate double efl_gfx_frame_controller_frame_duration_get_api_delegate(System.IntPtr obj,  int start_frame,  int frame_num);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate> efl_gfx_frame_controller_frame_duration_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_duration_get");

        private static double frame_duration_get(System.IntPtr obj, System.IntPtr pd, int start_frame, int frame_num)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_duration_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IFrameController)ws.Target).GetFrameDuration(start_frame, frame_num);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var;

            }
            else
            {
                return efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_frame, frame_num);
            }
        }

        private static efl_gfx_frame_controller_frame_duration_get_delegate efl_gfx_frame_controller_frame_duration_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxIFrameControllerConcrete_ExtensionMethods {
    
    public static Efl.BindableProperty<int> Frame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IFrameController, T>magic = null) where T : Efl.Gfx.IFrameController {
        return new Efl.BindableProperty<int>("frame", fac);
    }

    
    
    
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Gfx {

/// <summary>Frame loop modes</summary>
[Efl.Eo.BindingEntity]
public enum FrameControllerLoopHint
{
/// <summary>No looping order specified.</summary>
None = 0,
/// <summary>Standard loop: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Loop = 1,
/// <summary>Ping-pong bouncing loop: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1</summary>
Pingpong = 2,
}

}

}

