#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl rotate animation class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.AnimationRotate.NativeMethods]
[Efl.Eo.BindingEntity]
public class AnimationRotate : Efl.Canvas.Animation
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AnimationRotate))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_animation_rotate_class_get();
    /// <summary>Initializes a new instance of the <see cref="AnimationRotate"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public AnimationRotate(Efl.Object parent= null
            ) : base(efl_canvas_animation_rotate_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected AnimationRotate(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationRotate"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AnimationRotate(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationRotate"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AnimationRotate(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Rotate property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    virtual public void GetRotate(out double from_degree, out double to_degree, out Efl.Canvas.Object pivot, out double cx, out double cy) {
                                                                                                                                 Efl.Canvas.AnimationRotate.NativeMethods.efl_animation_rotate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out from_degree, out to_degree, out pivot, out cx, out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Rotate property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    virtual public void SetRotate(double from_degree, double to_degree, Efl.Canvas.Object pivot, double cx, double cy) {
                                                                                                                                 Efl.Canvas.AnimationRotate.NativeMethods.efl_animation_rotate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from_degree, to_degree, pivot, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Rotate absolute property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    virtual public void GetRotateAbsolute(out double from_degree, out double to_degree, out int cx, out int cy) {
                                                                                                         Efl.Canvas.AnimationRotate.NativeMethods.efl_animation_rotate_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out from_degree, out to_degree, out cx, out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Rotate absolute property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    virtual public void SetRotateAbsolute(double from_degree, double to_degree, int cx, int cy) {
                                                                                                         Efl.Canvas.AnimationRotate.NativeMethods.efl_animation_rotate_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from_degree, to_degree, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Rotate property</summary>
    /// <value>Rotation degree when animation starts</value>
    public (double, double, Efl.Canvas.Object, double, double) Rotate {
        get {
            double _out_from_degree = default(double);
            double _out_to_degree = default(double);
            Efl.Canvas.Object _out_pivot = default(Efl.Canvas.Object);
            double _out_cx = default(double);
            double _out_cy = default(double);
            GetRotate(out _out_from_degree,out _out_to_degree,out _out_pivot,out _out_cx,out _out_cy);
            return (_out_from_degree,_out_to_degree,_out_pivot,_out_cx,_out_cy);
        }
        set { SetRotate( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
    }
    /// <summary>Rotate absolute property</summary>
    /// <value>Rotation degree when animation starts</value>
    public (double, double, int, int) RotateAbsolute {
        get {
            double _out_from_degree = default(double);
            double _out_to_degree = default(double);
            int _out_cx = default(int);
            int _out_cy = default(int);
            GetRotateAbsolute(out _out_from_degree,out _out_to_degree,out _out_cx,out _out_cy);
            return (_out_from_degree,_out_to_degree,_out_cx,_out_cy);
        }
        set { SetRotateAbsolute( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.AnimationRotate.efl_canvas_animation_rotate_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Animation.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_animation_rotate_get_static_delegate == null)
            {
                efl_animation_rotate_get_static_delegate = new efl_animation_rotate_get_delegate(rotate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRotate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_get_static_delegate) });
            }

            if (efl_animation_rotate_set_static_delegate == null)
            {
                efl_animation_rotate_set_static_delegate = new efl_animation_rotate_set_delegate(rotate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRotate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_set_static_delegate) });
            }

            if (efl_animation_rotate_absolute_get_static_delegate == null)
            {
                efl_animation_rotate_absolute_get_static_delegate = new efl_animation_rotate_absolute_get_delegate(rotate_absolute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRotateAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_get_static_delegate) });
            }

            if (efl_animation_rotate_absolute_set_static_delegate == null)
            {
                efl_animation_rotate_absolute_set_static_delegate = new efl_animation_rotate_absolute_set_delegate(rotate_absolute_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRotateAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.AnimationRotate.efl_canvas_animation_rotate_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_animation_rotate_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object pivot,  out double cx,  out double cy);

        
        public delegate void efl_animation_rotate_get_api_delegate(System.IntPtr obj,  out double from_degree,  out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object pivot,  out double cx,  out double cy);

        public static Efl.Eo.FunctionWrapper<efl_animation_rotate_get_api_delegate> efl_animation_rotate_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_get_api_delegate>(Module, "efl_animation_rotate_get");

        private static void rotate_get(System.IntPtr obj, System.IntPtr pd, out double from_degree, out double to_degree, out Efl.Canvas.Object pivot, out double cx, out double cy)
        {
            Eina.Log.Debug("function efl_animation_rotate_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                from_degree = default(double);        to_degree = default(double);        pivot = default(Efl.Canvas.Object);        cx = default(double);        cy = default(double);                                                    
                try
                {
                    ((AnimationRotate)ws.Target).GetRotate(out from_degree, out to_degree, out pivot, out cx, out cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_animation_rotate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out from_degree, out to_degree, out pivot, out cx, out cy);
            }
        }

        private static efl_animation_rotate_get_delegate efl_animation_rotate_get_static_delegate;

        
        private delegate void efl_animation_rotate_set_delegate(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object pivot,  double cx,  double cy);

        
        public delegate void efl_animation_rotate_set_api_delegate(System.IntPtr obj,  double from_degree,  double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object pivot,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_animation_rotate_set_api_delegate> efl_animation_rotate_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_set_api_delegate>(Module, "efl_animation_rotate_set");

        private static void rotate_set(System.IntPtr obj, System.IntPtr pd, double from_degree, double to_degree, Efl.Canvas.Object pivot, double cx, double cy)
        {
            Eina.Log.Debug("function efl_animation_rotate_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((AnimationRotate)ws.Target).SetRotate(from_degree, to_degree, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_animation_rotate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), from_degree, to_degree, pivot, cx, cy);
            }
        }

        private static efl_animation_rotate_set_delegate efl_animation_rotate_set_static_delegate;

        
        private delegate void efl_animation_rotate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out int cx,  out int cy);

        
        public delegate void efl_animation_rotate_absolute_get_api_delegate(System.IntPtr obj,  out double from_degree,  out double to_degree,  out int cx,  out int cy);

        public static Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate> efl_animation_rotate_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate>(Module, "efl_animation_rotate_absolute_get");

        private static void rotate_absolute_get(System.IntPtr obj, System.IntPtr pd, out double from_degree, out double to_degree, out int cx, out int cy)
        {
            Eina.Log.Debug("function efl_animation_rotate_absolute_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        from_degree = default(double);        to_degree = default(double);        cx = default(int);        cy = default(int);                                            
                try
                {
                    ((AnimationRotate)ws.Target).GetRotateAbsolute(out from_degree, out to_degree, out cx, out cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_animation_rotate_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out from_degree, out to_degree, out cx, out cy);
            }
        }

        private static efl_animation_rotate_absolute_get_delegate efl_animation_rotate_absolute_get_static_delegate;

        
        private delegate void efl_animation_rotate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,  int cx,  int cy);

        
        public delegate void efl_animation_rotate_absolute_set_api_delegate(System.IntPtr obj,  double from_degree,  double to_degree,  int cx,  int cy);

        public static Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate> efl_animation_rotate_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate>(Module, "efl_animation_rotate_absolute_set");

        private static void rotate_absolute_set(System.IntPtr obj, System.IntPtr pd, double from_degree, double to_degree, int cx, int cy)
        {
            Eina.Log.Debug("function efl_animation_rotate_absolute_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((AnimationRotate)ws.Target).SetRotateAbsolute(from_degree, to_degree, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_animation_rotate_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), from_degree, to_degree, cx, cy);
            }
        }

        private static efl_animation_rotate_absolute_set_delegate efl_animation_rotate_absolute_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasAnimationRotate_ExtensionMethods {
    
    
}
#pragma warning restore CS1591
#endif
