#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.GestureLongTap.GestureLongTapEvt"/>.</summary>
public class GestureLongTapGestureLongTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.Gesture arg { get; set; }
}
/// <summary>EFL Gesture Long Tap class</summary>
[GestureLongTapNativeInherit]
public class GestureLongTap : Efl.Canvas.Gesture, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (GestureLongTap))
                return Efl.Canvas.GestureLongTapNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_long_tap_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public GestureLongTap(Efl.Object parent= null
            ) :
        base(efl_canvas_gesture_long_tap_class_get(), typeof(GestureLongTap), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected GestureLongTap(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected GestureLongTap(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object GestureLongTapEvtKey = new object();
    /// <summary>Event for tap gesture</summary>
    public event EventHandler<Efl.Canvas.GestureLongTapGestureLongTapEvt_Args> GestureLongTapEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_GESTURE_LONG_TAP";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_GestureLongTapEvt_delegate)) {
                    eventHandlers.AddHandler(GestureLongTapEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_GESTURE_LONG_TAP";
                if (RemoveNativeEventHandler(key, this.evt_GestureLongTapEvt_delegate)) { 
                    eventHandlers.RemoveHandler(GestureLongTapEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event GestureLongTapEvt.</summary>
    public void On_GestureLongTapEvt(Efl.Canvas.GestureLongTapGestureLongTapEvt_Args e)
    {
        EventHandler<Efl.Canvas.GestureLongTapGestureLongTapEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Canvas.GestureLongTapGestureLongTapEvt_Args>)eventHandlers[GestureLongTapEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_GestureLongTapEvt_delegate;
    private void on_GestureLongTapEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Canvas.GestureLongTapGestureLongTapEvt_Args args = new Efl.Canvas.GestureLongTapGestureLongTapEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.Gesture);
        try {
            On_GestureLongTapEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_GestureLongTapEvt_delegate = new Efl.EventCb(on_GestureLongTapEvt_NativeCallback);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureLongTap.efl_canvas_gesture_long_tap_class_get();
    }
}
public class GestureLongTapNativeInherit : Efl.Canvas.GestureNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Canvas.GestureLongTap.efl_canvas_gesture_long_tap_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureLongTap.efl_canvas_gesture_long_tap_class_get();
    }
}
} } 
