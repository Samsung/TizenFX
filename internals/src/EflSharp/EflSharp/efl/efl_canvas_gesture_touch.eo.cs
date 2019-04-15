#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>EFL Gesture Touch class</summary>
[GestureTouchNativeInherit]
public class GestureTouch : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (GestureTouch))
                return Efl.Canvas.GestureTouchNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_touch_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public GestureTouch(Efl.Object parent= null
            ) :
        base(efl_canvas_gesture_touch_class_get(), typeof(GestureTouch), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected GestureTouch(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected GestureTouch(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>Returns the first touch point.</summary>
    /// <returns>The start position.</returns>
    virtual public Eina.Vector2 GetStartPoint() {
         var _ret_var = Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_start_point_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property tells if the event is multi touch.</summary>
    /// <returns>returns <c>true</c> if its a multi touch</returns>
    virtual public bool GetMultiTouch() {
         var _ret_var = Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_multi_touch_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property holds the state of the touch event.</summary>
    /// <returns>touch event state</returns>
    virtual public Efl.Canvas.GestureTouchState GetState() {
         var _ret_var = Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_state_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Touch point record method</summary>
    /// <param name="tool">The finger id</param>
    /// <param name="pos">Position of the event</param>
    /// <param name="timestamp">The timestamp of the event</param>
    /// <param name="action">action of the event</param>
    /// <returns></returns>
    virtual public void PointRecord( int tool,  Eina.Vector2 pos,  double timestamp,  Efl.Pointer.Action action) {
                 Eina.Vector2.NativeStruct _in_pos = pos;
                                                                                        Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_point_record_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), tool,  _in_pos,  timestamp,  action);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Compute the distance between the last two events</summary>
    /// <param name="tool">The finger id</param>
    /// <returns>The distance vector.</returns>
    virtual public Eina.Vector2 Delta( int tool) {
                                 var _ret_var = Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_delta_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), tool);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Compute the distance between the first touch and the last event.</summary>
    /// <param name="tool">The finger id</param>
    /// <returns>The distance vector.</returns>
    virtual public Eina.Vector2 Distance( int tool) {
                                 var _ret_var = Efl.Canvas.GestureTouchNativeInherit.efl_gesture_touch_distance_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), tool);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the first touch point.</summary>
/// <value>The start position.</value>
    public Eina.Vector2 StartPoint {
        get { return GetStartPoint(); }
    }
    /// <summary>This property tells if the event is multi touch.</summary>
/// <value>returns <c>true</c> if its a multi touch</value>
    public bool MultiTouch {
        get { return GetMultiTouch(); }
    }
    /// <summary>This property holds the state of the touch event.</summary>
/// <value>touch event state</value>
    public Efl.Canvas.GestureTouchState State {
        get { return GetState(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureTouch.efl_canvas_gesture_touch_class_get();
    }
}
public class GestureTouchNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gesture_touch_start_point_get_static_delegate == null)
            efl_gesture_touch_start_point_get_static_delegate = new efl_gesture_touch_start_point_get_delegate(start_point_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStartPoint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_start_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_start_point_get_static_delegate)});
        if (efl_gesture_touch_multi_touch_get_static_delegate == null)
            efl_gesture_touch_multi_touch_get_static_delegate = new efl_gesture_touch_multi_touch_get_delegate(multi_touch_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMultiTouch") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_multi_touch_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_multi_touch_get_static_delegate)});
        if (efl_gesture_touch_state_get_static_delegate == null)
            efl_gesture_touch_state_get_static_delegate = new efl_gesture_touch_state_get_delegate(state_get);
        if (methods.FirstOrDefault(m => m.Name == "GetState") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_state_get_static_delegate)});
        if (efl_gesture_touch_point_record_static_delegate == null)
            efl_gesture_touch_point_record_static_delegate = new efl_gesture_touch_point_record_delegate(point_record);
        if (methods.FirstOrDefault(m => m.Name == "PointRecord") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_point_record"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_point_record_static_delegate)});
        if (efl_gesture_touch_delta_static_delegate == null)
            efl_gesture_touch_delta_static_delegate = new efl_gesture_touch_delta_delegate(delta);
        if (methods.FirstOrDefault(m => m.Name == "Delta") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_delta"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_delta_static_delegate)});
        if (efl_gesture_touch_distance_static_delegate == null)
            efl_gesture_touch_distance_static_delegate = new efl_gesture_touch_distance_delegate(distance);
        if (methods.FirstOrDefault(m => m.Name == "Distance") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gesture_touch_distance"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_touch_distance_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Canvas.GestureTouch.efl_canvas_gesture_touch_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureTouch.efl_canvas_gesture_touch_class_get();
    }


     private delegate Eina.Vector2.NativeStruct efl_gesture_touch_start_point_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Vector2.NativeStruct efl_gesture_touch_start_point_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_start_point_get_api_delegate> efl_gesture_touch_start_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_start_point_get_api_delegate>(_Module, "efl_gesture_touch_start_point_get");
     private static Eina.Vector2.NativeStruct start_point_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gesture_touch_start_point_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Vector2 _ret_var = default(Eina.Vector2);
            try {
                _ret_var = ((GestureTouch)wrapper).GetStartPoint();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gesture_touch_start_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gesture_touch_start_point_get_delegate efl_gesture_touch_start_point_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gesture_touch_multi_touch_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gesture_touch_multi_touch_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_multi_touch_get_api_delegate> efl_gesture_touch_multi_touch_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_multi_touch_get_api_delegate>(_Module, "efl_gesture_touch_multi_touch_get");
     private static bool multi_touch_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gesture_touch_multi_touch_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((GestureTouch)wrapper).GetMultiTouch();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gesture_touch_multi_touch_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gesture_touch_multi_touch_get_delegate efl_gesture_touch_multi_touch_get_static_delegate;


     private delegate Efl.Canvas.GestureTouchState efl_gesture_touch_state_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Canvas.GestureTouchState efl_gesture_touch_state_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_state_get_api_delegate> efl_gesture_touch_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_state_get_api_delegate>(_Module, "efl_gesture_touch_state_get");
     private static Efl.Canvas.GestureTouchState state_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gesture_touch_state_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Canvas.GestureTouchState _ret_var = default(Efl.Canvas.GestureTouchState);
            try {
                _ret_var = ((GestureTouch)wrapper).GetState();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gesture_touch_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gesture_touch_state_get_delegate efl_gesture_touch_state_get_static_delegate;


     private delegate void efl_gesture_touch_point_record_delegate(System.IntPtr obj, System.IntPtr pd,   int tool,   Eina.Vector2.NativeStruct pos,   double timestamp,   Efl.Pointer.Action action);


     public delegate void efl_gesture_touch_point_record_api_delegate(System.IntPtr obj,   int tool,   Eina.Vector2.NativeStruct pos,   double timestamp,   Efl.Pointer.Action action);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_point_record_api_delegate> efl_gesture_touch_point_record_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_point_record_api_delegate>(_Module, "efl_gesture_touch_point_record");
     private static void point_record(System.IntPtr obj, System.IntPtr pd,  int tool,  Eina.Vector2.NativeStruct pos,  double timestamp,  Efl.Pointer.Action action)
    {
        Eina.Log.Debug("function efl_gesture_touch_point_record was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                            Eina.Vector2 _in_pos = pos;
                                                                                            
            try {
                ((GestureTouch)wrapper).PointRecord( tool,  _in_pos,  timestamp,  action);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gesture_touch_point_record_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  tool,  pos,  timestamp,  action);
        }
    }
    private static efl_gesture_touch_point_record_delegate efl_gesture_touch_point_record_static_delegate;


     private delegate Eina.Vector2.NativeStruct efl_gesture_touch_delta_delegate(System.IntPtr obj, System.IntPtr pd,   int tool);


     public delegate Eina.Vector2.NativeStruct efl_gesture_touch_delta_api_delegate(System.IntPtr obj,   int tool);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_delta_api_delegate> efl_gesture_touch_delta_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_delta_api_delegate>(_Module, "efl_gesture_touch_delta");
     private static Eina.Vector2.NativeStruct delta(System.IntPtr obj, System.IntPtr pd,  int tool)
    {
        Eina.Log.Debug("function efl_gesture_touch_delta was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Vector2 _ret_var = default(Eina.Vector2);
            try {
                _ret_var = ((GestureTouch)wrapper).Delta( tool);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gesture_touch_delta_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  tool);
        }
    }
    private static efl_gesture_touch_delta_delegate efl_gesture_touch_delta_static_delegate;


     private delegate Eina.Vector2.NativeStruct efl_gesture_touch_distance_delegate(System.IntPtr obj, System.IntPtr pd,   int tool);


     public delegate Eina.Vector2.NativeStruct efl_gesture_touch_distance_api_delegate(System.IntPtr obj,   int tool);
     public static Efl.Eo.FunctionWrapper<efl_gesture_touch_distance_api_delegate> efl_gesture_touch_distance_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_touch_distance_api_delegate>(_Module, "efl_gesture_touch_distance");
     private static Eina.Vector2.NativeStruct distance(System.IntPtr obj, System.IntPtr pd,  int tool)
    {
        Eina.Log.Debug("function efl_gesture_touch_distance was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Vector2 _ret_var = default(Eina.Vector2);
            try {
                _ret_var = ((GestureTouch)wrapper).Distance( tool);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gesture_touch_distance_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  tool);
        }
    }
    private static efl_gesture_touch_distance_delegate efl_gesture_touch_distance_static_delegate;
}
} } 
