#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
///<summary>Event argument wrapper for event <see cref="Efl.SelectModel.SelectedEvt"/>.</summary>
public class SelectModelSelectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.SelectModel.UnselectedEvt"/>.</summary>
public class SelectModelUnselectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
/// <summary>Efl select model class</summary>
[SelectModelNativeInherit]
public class SelectModel : Efl.BooleanModel, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (SelectModel))
                return Efl.SelectModelNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_select_model_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel"/></param>
    ///<param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex"/></param>
    public SelectModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) :
        base(efl_select_model_class_get(), typeof(SelectModel), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        if (Efl.Eo.Globals.ParamHelperCheck(index))
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected SelectModel(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected SelectModel(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object SelectedEvtKey = new object();
    /// <summary></summary>
    public event EventHandler<Efl.SelectModelSelectedEvt_Args> SelectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_SELECT_MODEL_EVENT_SELECTED";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_SelectedEvt_delegate)) {
                    eventHandlers.AddHandler(SelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_SELECT_MODEL_EVENT_SELECTED";
                if (RemoveNativeEventHandler(key, this.evt_SelectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectedEvt.</summary>
    public void On_SelectedEvt(Efl.SelectModelSelectedEvt_Args e)
    {
        EventHandler<Efl.SelectModelSelectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.SelectModelSelectedEvt_Args>)eventHandlers[SelectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectedEvt_delegate;
    private void on_SelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.SelectModelSelectedEvt_Args args = new Efl.SelectModelSelectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_SelectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object UnselectedEvtKey = new object();
    /// <summary></summary>
    public event EventHandler<Efl.SelectModelUnselectedEvt_Args> UnselectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_SELECT_MODEL_EVENT_UNSELECTED";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_UnselectedEvt_delegate)) {
                    eventHandlers.AddHandler(UnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_SELECT_MODEL_EVENT_UNSELECTED";
                if (RemoveNativeEventHandler(key, this.evt_UnselectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(UnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event UnselectedEvt.</summary>
    public void On_UnselectedEvt(Efl.SelectModelUnselectedEvt_Args e)
    {
        EventHandler<Efl.SelectModelUnselectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.SelectModelUnselectedEvt_Args>)eventHandlers[UnselectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_UnselectedEvt_delegate;
    private void on_UnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.SelectModelUnselectedEvt_Args args = new Efl.SelectModelUnselectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_UnselectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_SelectedEvt_delegate = new Efl.EventCb(on_SelectedEvt_NativeCallback);
        evt_UnselectedEvt_delegate = new Efl.EventCb(on_UnselectedEvt_NativeCallback);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.SelectModel.efl_select_model_class_get();
    }
}
public class SelectModelNativeInherit : Efl.BooleanModelNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.SelectModel.efl_select_model_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.SelectModel.efl_select_model_class_get();
    }
}
} 
