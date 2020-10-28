#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl scale animation class</summary>
[AnimationScaleNativeInherit]
public class AnimationScale : Efl.Canvas.Animation, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (AnimationScale))
                return Efl.Canvas.AnimationScaleNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_animation_scale_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public AnimationScale(Efl.Object parent= null
            ) :
        base(efl_canvas_animation_scale_class_get(), typeof(AnimationScale), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected AnimationScale(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected AnimationScale(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>Scale property</summary>
    /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
    /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
    /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
    /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is scaled on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    /// <returns></returns>
    virtual public void GetScale( out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out Efl.Canvas.Object pivot,  out double cx,  out double cy) {
                                                                                                                                                                                 Efl.Canvas.AnimationScaleNativeInherit.efl_animation_scale_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Scale property</summary>
    /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
    /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
    /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
    /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
    /// <param name="pivot">Pivot object for the center point. If the pivot object is NULL, then the object is scaled on itself.</param>
    /// <param name="cx">X relative coordinate of the center point. The left end is 0.0 and the right end is 1.0 (the center is 0.5).</param>
    /// <param name="cy">Y relative coordinate of the center point. The top end is 0.0 and the bottom end is 1.0 (the center is 0.5).</param>
    /// <returns></returns>
    virtual public void SetScale( double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  Efl.Canvas.Object pivot,  double cx,  double cy) {
                                                                                                                                                                                 Efl.Canvas.AnimationScaleNativeInherit.efl_animation_scale_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Scale absolute property</summary>
    /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
    /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
    /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
    /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    /// <returns></returns>
    virtual public void GetScaleAbsolute( out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out int cx,  out int cy) {
                                                                                                                                                         Efl.Canvas.AnimationScaleNativeInherit.efl_animation_scale_absolute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Scale absolute property</summary>
    /// <param name="from_scale_x">Scale factor along x axis when animation starts</param>
    /// <param name="from_scale_y">Scale factor along y axis when animation starts</param>
    /// <param name="to_scale_x">Scale factor along x axis when animation ends</param>
    /// <param name="to_scale_y">Scale factor along y axis when animation ends</param>
    /// <param name="cx">X absolute coordinate of the center point.</param>
    /// <param name="cy">Y absolute coordinate of the center point.</param>
    /// <returns></returns>
    virtual public void SetScaleAbsolute( double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  int cx,  int cy) {
                                                                                                                                                         Efl.Canvas.AnimationScaleNativeInherit.efl_animation_scale_absolute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.AnimationScale.efl_canvas_animation_scale_class_get();
    }
}
public class AnimationScaleNativeInherit : Efl.Canvas.AnimationNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_animation_scale_get_static_delegate == null)
            efl_animation_scale_get_static_delegate = new efl_animation_scale_get_delegate(scale_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_get_static_delegate)});
        if (efl_animation_scale_set_static_delegate == null)
            efl_animation_scale_set_static_delegate = new efl_animation_scale_set_delegate(scale_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_set_static_delegate)});
        if (efl_animation_scale_absolute_get_static_delegate == null)
            efl_animation_scale_absolute_get_static_delegate = new efl_animation_scale_absolute_get_delegate(scale_absolute_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScaleAbsolute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_scale_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_absolute_get_static_delegate)});
        if (efl_animation_scale_absolute_set_static_delegate == null)
            efl_animation_scale_absolute_set_static_delegate = new efl_animation_scale_absolute_set_delegate(scale_absolute_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScaleAbsolute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_animation_scale_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_scale_absolute_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Canvas.AnimationScale.efl_canvas_animation_scale_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.AnimationScale.efl_canvas_animation_scale_class_get();
    }


     private delegate void efl_animation_scale_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);


     public delegate void efl_animation_scale_get_api_delegate(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  out Efl.Canvas.Object pivot,   out double cx,   out double cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_scale_get_api_delegate> efl_animation_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_scale_get_api_delegate>(_Module, "efl_animation_scale_get");
     private static void scale_get(System.IntPtr obj, System.IntPtr pd,  out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out Efl.Canvas.Object pivot,  out double cx,  out double cy)
    {
        Eina.Log.Debug("function efl_animation_scale_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                            from_scale_x = default(double);        from_scale_y = default(double);        to_scale_x = default(double);        to_scale_y = default(double);        pivot = default(Efl.Canvas.Object);        cx = default(double);        cy = default(double);                                                                    
            try {
                ((AnimationScale)wrapper).GetScale( out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                                } else {
            efl_animation_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out pivot,  out cx,  out cy);
        }
    }
    private static efl_animation_scale_get_delegate efl_animation_scale_get_static_delegate;


     private delegate void efl_animation_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);


     public delegate void efl_animation_scale_set_api_delegate(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object pivot,   double cx,   double cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_scale_set_api_delegate> efl_animation_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_scale_set_api_delegate>(_Module, "efl_animation_scale_set");
     private static void scale_set(System.IntPtr obj, System.IntPtr pd,  double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  Efl.Canvas.Object pivot,  double cx,  double cy)
    {
        Eina.Log.Debug("function efl_animation_scale_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                                                                
            try {
                ((AnimationScale)wrapper).SetScale( from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                                } else {
            efl_animation_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  pivot,  cx,  cy);
        }
    }
    private static efl_animation_scale_set_delegate efl_animation_scale_set_static_delegate;


     private delegate void efl_animation_scale_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y,   out int cx,   out int cy);


     public delegate void efl_animation_scale_absolute_get_api_delegate(System.IntPtr obj,   out double from_scale_x,   out double from_scale_y,   out double to_scale_x,   out double to_scale_y,   out int cx,   out int cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_scale_absolute_get_api_delegate> efl_animation_scale_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_scale_absolute_get_api_delegate>(_Module, "efl_animation_scale_absolute_get");
     private static void scale_absolute_get(System.IntPtr obj, System.IntPtr pd,  out double from_scale_x,  out double from_scale_y,  out double to_scale_x,  out double to_scale_y,  out int cx,  out int cy)
    {
        Eina.Log.Debug("function efl_animation_scale_absolute_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                    from_scale_x = default(double);        from_scale_y = default(double);        to_scale_x = default(double);        to_scale_y = default(double);        cx = default(int);        cy = default(int);                                                            
            try {
                ((AnimationScale)wrapper).GetScaleAbsolute( out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                } else {
            efl_animation_scale_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out from_scale_x,  out from_scale_y,  out to_scale_x,  out to_scale_y,  out cx,  out cy);
        }
    }
    private static efl_animation_scale_absolute_get_delegate efl_animation_scale_absolute_get_static_delegate;


     private delegate void efl_animation_scale_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y,   int cx,   int cy);


     public delegate void efl_animation_scale_absolute_set_api_delegate(System.IntPtr obj,   double from_scale_x,   double from_scale_y,   double to_scale_x,   double to_scale_y,   int cx,   int cy);
     public static Efl.Eo.FunctionWrapper<efl_animation_scale_absolute_set_api_delegate> efl_animation_scale_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_scale_absolute_set_api_delegate>(_Module, "efl_animation_scale_absolute_set");
     private static void scale_absolute_set(System.IntPtr obj, System.IntPtr pd,  double from_scale_x,  double from_scale_y,  double to_scale_x,  double to_scale_y,  int cx,  int cy)
    {
        Eina.Log.Debug("function efl_animation_scale_absolute_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                                        
            try {
                ((AnimationScale)wrapper).SetScaleAbsolute( from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                } else {
            efl_animation_scale_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  from_scale_x,  from_scale_y,  to_scale_x,  to_scale_y,  cx,  cy);
        }
    }
    private static efl_animation_scale_absolute_set_delegate efl_animation_scale_absolute_set_static_delegate;
}
} } 
