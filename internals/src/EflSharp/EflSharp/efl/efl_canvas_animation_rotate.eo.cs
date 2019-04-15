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
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (AnimationRotate))
                return Efl.Canvas.AnimationRotateNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_animation_rotate_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public AnimationRotate(Efl.Object parent= null
            ) :
        base(efl_canvas_animation_rotate_class_get(), typeof(AnimationRotate), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected AnimationRotate(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected AnimationRotate(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Rotate property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    /// <returns></returns>
    virtual public void GetRotate( out double from_degree,  out double to_degree,  out Efl.Canvas.Object pivot,  out double cx,  out double cy) {
                                                                                                                                 Efl.Canvas.AnimationRotateNativeInherit.efl_animation_rotate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Rotate property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is rotated on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    /// <returns></returns>
    virtual public void SetRotate( double from_degree,  double to_degree,  Efl.Canvas.Object pivot,  double cx,  double cy) {
                                                                                                                                 Efl.Canvas.AnimationRotateNativeInherit.efl_animation_rotate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from_degree,  to_degree,  pivot,  cx,  cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Rotate absolute property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    /// <returns></returns>
    virtual public void GetRotateAbsolute( out double from_degree,  out double to_degree,  out int cx,  out int cy) {
                                                                                                         Efl.Canvas.AnimationRotateNativeInherit.efl_animation_rotate_absolute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from_degree,  out to_degree,  out cx,  out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Rotate absolute property</summary>
    /// <param name="from_degree">Rotation degree when animation starts</param>
    /// <param name="to_degree">Rotation degree when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    /// <returns></returns>
    virtual public void SetRotateAbsolute( double from_degree,  double to_degree,  int cx,  int cy) {
                                                                                                         Efl.Canvas.AnimationRotateNativeInherit.efl_animation_rotate_absolute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from_degree,  to_degree,  cx,  cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.AnimationRotate.efl_canvas_animation_rotate_class_get();
    }
}
public class AnimationRotateNativeInherit : Efl.Canvas.AnimationNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_animation_rotate_get_static_delegate == null)
            efl_animation_rotate_get_static_delegate = new efl_animation_rotate_get_delegate(rotate_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRotate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_rotate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_get_static_delegate)});
        if (efl_animation_rotate_set_static_delegate == null)
            efl_animation_rotate_set_static_delegate = new efl_animation_rotate_set_delegate(rotate_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRotate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_rotate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_set_static_delegate)});
        if (efl_animation_rotate_absolute_get_static_delegate == null)
            efl_animation_rotate_absolute_get_static_delegate = new efl_animation_rotate_absolute_get_delegate(rotate_absolute_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRotateAbsolute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_rotate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_get_static_delegate)});
        if (efl_animation_rotate_absolute_set_static_delegate == null)
            efl_animation_rotate_absolute_set_static_delegate = new efl_animation_rotate_absolute_set_delegate(rotate_absolute_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRotateAbsolute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_rotate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_set_static_delegate)});
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


     private delegate void efl_animation_rotate_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_degree,   out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);


     public delegate void efl_animation_rotate_get_api_delegate(System.IntPtr obj,   out double from_degree,   out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_rotate_get_api_delegate> efl_animation_rotate_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_get_api_delegate>(_Module, "efl_animation_rotate_get");
     private static void rotate_get(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out Efl.Canvas.Object pivot,  out double cx,  out double cy)
    {
        Eina.Log.Debug("function efl_animation_rotate_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                            from_degree = default(double);        to_degree = default(double);        pivot = default(Efl.Canvas.Object);        cx = default(double);        cy = default(double);                                                    
            try {
                ((AnimationRotate)wrapper).GetRotate( out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                } else {
            efl_animation_rotate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_degree,  out to_degree,  out pivot,  out cx,  out cy);
        }
    }
    private static efl_animation_rotate_get_delegate efl_animation_rotate_get_static_delegate;


     private delegate void efl_animation_rotate_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_degree,   double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);


     public delegate void efl_animation_rotate_set_api_delegate(System.IntPtr obj,   double from_degree,   double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_rotate_set_api_delegate> efl_animation_rotate_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_set_api_delegate>(_Module, "efl_animation_rotate_set");
     private static void rotate_set(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,  Efl.Canvas.Object pivot,  double cx,  double cy)
    {
        Eina.Log.Debug("function efl_animation_rotate_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                
            try {
                ((AnimationRotate)wrapper).SetRotate( from_degree,  to_degree,  pivot,  cx,  cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                } else {
            efl_animation_rotate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_degree,  to_degree,  pivot,  cx,  cy);
        }
    }
    private static efl_animation_rotate_set_delegate efl_animation_rotate_set_static_delegate;


     private delegate void efl_animation_rotate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_degree,   out double to_degree,   out int cx,   out int cy);


     public delegate void efl_animation_rotate_absolute_get_api_delegate(System.IntPtr obj,   out double from_degree,   out double to_degree,   out int cx,   out int cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate> efl_animation_rotate_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate>(_Module, "efl_animation_rotate_absolute_get");
     private static void rotate_absolute_get(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out int cx,  out int cy)
    {
        Eina.Log.Debug("function efl_animation_rotate_absolute_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    from_degree = default(double);        to_degree = default(double);        cx = default(int);        cy = default(int);                                            
            try {
                ((AnimationRotate)wrapper).GetRotateAbsolute( out from_degree,  out to_degree,  out cx,  out cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_animation_rotate_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_degree,  out to_degree,  out cx,  out cy);
        }
    }
    private static efl_animation_rotate_absolute_get_delegate efl_animation_rotate_absolute_get_static_delegate;


     private delegate void efl_animation_rotate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_degree,   double to_degree,   int cx,   int cy);


     public delegate void efl_animation_rotate_absolute_set_api_delegate(System.IntPtr obj,   double from_degree,   double to_degree,   int cx,   int cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate> efl_animation_rotate_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate>(_Module, "efl_animation_rotate_absolute_set");
     private static void rotate_absolute_set(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,  int cx,  int cy)
    {
        Eina.Log.Debug("function efl_animation_rotate_absolute_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((AnimationRotate)wrapper).SetRotateAbsolute( from_degree,  to_degree,  cx,  cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_animation_rotate_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_degree,  to_degree,  cx,  cy);
        }
    }
    private static efl_animation_rotate_absolute_set_delegate efl_animation_rotate_absolute_set_static_delegate;
}
} } 
