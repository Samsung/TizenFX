#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.GestureTap.GestureTapEvt"/>.</summary>
public class GestureTapGestureTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.Gesture arg { get; set; }
}
/// <summary>EFL Gesture Tap class</summary>
[GestureTapNativeInherit]
public class GestureTap : Efl.Canvas.Gesture, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (GestureTap))
                return Efl.Canvas.GestureTapNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_tap_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public GestureTap(Efl.Object parent= null
            ) :
        base(efl_canvas_gesture_tap_class_get(), typeof(GestureTap), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected GestureTap(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected GestureTap(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object GestureTapEvtKey = new object();
    /// <summary>Event for tap gesture</summary>
    public event EventHandler<Efl.Canvas.GestureTapGestureTapEvt_Args> GestureTapEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_GESTURE_TAP";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_GestureTapEvt_delegate)) {
                    eventHandlers.AddHandler(GestureTapEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_GESTURE_TAP";
                if (RemoveNativeEventHandler(key, this.evt_GestureTapEvt_delegate)) { 
                    eventHandlers.RemoveHandler(GestureTapEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event GestureTapEvt.</summary>
    public void On_GestureTapEvt(Efl.Canvas.GestureTapGestureTapEvt_Args e)
    {
        EventHandler<Efl.Canvas.GestureTapGestureTapEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Canvas.GestureTapGestureTapEvt_Args>)eventHandlers[GestureTapEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_GestureTapEvt_delegate;
    private void on_GestureTapEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Canvas.GestureTapGestureTapEvt_Args args = new Efl.Canvas.GestureTapGestureTapEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.Gesture);
        try {
            On_GestureTapEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_GestureTapEvt_delegate = new Efl.EventCb(on_GestureTapEvt_NativeCallback);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureTap.efl_canvas_gesture_tap_class_get();
    }
}
public class GestureTapNativeInherit : Efl.Canvas.GestureNativeInherit{
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
        return Efl.Canvas.GestureTap.efl_canvas_gesture_tap_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureTap.efl_canvas_gesture_tap_class_get();
    }
}
} } 
