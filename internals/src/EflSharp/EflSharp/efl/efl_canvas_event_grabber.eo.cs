#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Low-level rectangle object.
/// This provides a smart version of the typical &quot;event rectangle&quot;, which allows objects to set this as their parent and route events to a group of objects. Events will not propagate to non-member objects below this object.
/// 
/// Adding members is done just like a normal smart object, using efl_canvas_group_member_add (Eo API) or evas_object_smart_member_add (legacy).
/// 
/// Child objects are not modified in any way, unlike other types of smart objects.
/// 
/// No child objects should be stacked above the event grabber parent while the grabber is visible. A critical error will be raised if this is detected.</summary>
[EventGrabberNativeInherit]
public class EventGrabber : Efl.Canvas.Group, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (EventGrabber))
                return Efl.Canvas.EventGrabberNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_event_grabber_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public EventGrabber(Efl.Object parent= null
            ) :
        base(efl_canvas_event_grabber_class_get(), typeof(EventGrabber), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected EventGrabber(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected EventGrabber(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
    /// <returns>If <c>true</c>, stop updating</returns>
    virtual public bool GetFreezeWhenVisible() {
         var _ret_var = Efl.Canvas.EventGrabberNativeInherit.efl_canvas_event_grabber_freeze_when_visible_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
    /// <param name="set">If <c>true</c>, stop updating</param>
    /// <returns></returns>
    virtual public void SetFreezeWhenVisible( bool set) {
                                 Efl.Canvas.EventGrabberNativeInherit.efl_canvas_event_grabber_freeze_when_visible_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Stops the grabber from updating its internal stacking order while visible</summary>
/// <value>If <c>true</c>, stop updating</value>
    public bool FreezeWhenVisible {
        get { return GetFreezeWhenVisible(); }
        set { SetFreezeWhenVisible( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
    }
}
public class EventGrabberNativeInherit : Efl.Canvas.GroupNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_canvas_event_grabber_freeze_when_visible_get_static_delegate == null)
            efl_canvas_event_grabber_freeze_when_visible_get_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_get_delegate(freeze_when_visible_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFreezeWhenVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_event_grabber_freeze_when_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_get_static_delegate)});
        if (efl_canvas_event_grabber_freeze_when_visible_set_static_delegate == null)
            efl_canvas_event_grabber_freeze_when_visible_set_static_delegate = new efl_canvas_event_grabber_freeze_when_visible_set_delegate(freeze_when_visible_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFreezeWhenVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_event_grabber_freeze_when_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_event_grabber_freeze_when_visible_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.EventGrabber.efl_canvas_event_grabber_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_event_grabber_freeze_when_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_event_grabber_freeze_when_visible_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_get_api_delegate> efl_canvas_event_grabber_freeze_when_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_get_api_delegate>(_Module, "efl_canvas_event_grabber_freeze_when_visible_get");
     private static bool freeze_when_visible_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((EventGrabber)wrapper).GetFreezeWhenVisible();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_canvas_event_grabber_freeze_when_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_canvas_event_grabber_freeze_when_visible_get_delegate efl_canvas_event_grabber_freeze_when_visible_get_static_delegate;


     private delegate void efl_canvas_event_grabber_freeze_when_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool set);


     public delegate void efl_canvas_event_grabber_freeze_when_visible_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool set);
     public static Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_set_api_delegate> efl_canvas_event_grabber_freeze_when_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_event_grabber_freeze_when_visible_set_api_delegate>(_Module, "efl_canvas_event_grabber_freeze_when_visible_set");
     private static void freeze_when_visible_set(System.IntPtr obj, System.IntPtr pd,  bool set)
    {
        Eina.Log.Debug("function efl_canvas_event_grabber_freeze_when_visible_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((EventGrabber)wrapper).SetFreezeWhenVisible( set);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_canvas_event_grabber_freeze_when_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  set);
        }
    }
    private static efl_canvas_event_grabber_freeze_when_visible_set_delegate efl_canvas_event_grabber_freeze_when_visible_set_static_delegate;
}
} } 
