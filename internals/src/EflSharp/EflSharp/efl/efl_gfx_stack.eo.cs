#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
public partial class Constants {
    public static readonly short StackLayerMin = -32768;
}
} } 
namespace Efl { namespace Gfx { 
public partial class Constants {
    public static readonly short StackLayerMax = 32767;
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics stack interface
/// (Since EFL 1.22)</summary>
[IStackNativeInherit]
public interface IStack : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
/// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
/// (Since EFL 1.22)</summary>
/// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
short GetLayer();
    /// <summary>Sets the layer of its canvas that the given object will be part of.
/// If you don&apos;t use this function, you&apos;ll be dealing with an unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
/// 
/// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
/// 
/// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>
/// (Since EFL 1.22)</summary>
/// <param name="l">The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</param>
/// <returns></returns>
void SetLayer( short l);
    /// <summary>Get the Evas object stacked right below <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
Efl.Gfx.IStack GetBelow();
    /// <summary>Get the Evas object stacked right above <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
Efl.Gfx.IStack GetAbove();
    /// <summary>Stack <c>obj</c> immediately <c>below</c>
/// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
/// 
/// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
/// 
/// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>below</c> must also be a member of the same smart object.
/// 
/// Similarly, if <c>obj</c> is not a member of a smart object, <c>below</c> must not be either.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
/// (Since EFL 1.22)</summary>
/// <param name="below">The object below which to stack</param>
/// <returns></returns>
void StackBelow( Efl.Gfx.IStack below);
    /// <summary>Raise <c>obj</c> to the top of its layer.
/// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
/// 
/// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.LowerToBottom"/>
/// (Since EFL 1.22)</summary>
/// <returns></returns>
void RaiseToTop();
    /// <summary>Stack <c>obj</c> immediately <c>above</c>
/// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
/// 
/// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
/// 
/// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>above</c> must also be a member of the same smart object.
/// 
/// Similarly, if <c>obj</c> is not a member of a smart object, <c>above</c> must not be either.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
/// (Since EFL 1.22)</summary>
/// <param name="above">The object above which to stack</param>
/// <returns></returns>
void StackAbove( Efl.Gfx.IStack above);
    /// <summary>Lower <c>obj</c> to the bottom of its layer.
/// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
/// 
/// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.RaiseToTop"/>
/// (Since EFL 1.22)</summary>
/// <returns></returns>
void LowerToBottom();
                                    /// <summary>Object stacking was changed.
    /// (Since EFL 1.22)</summary>
    event EventHandler StackingChangedEvt;
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
/// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
/// (Since EFL 1.22)</summary>
/// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
    short Layer {
        get ;
        set ;
    }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    Efl.Gfx.IStack Below {
        get ;
    }
    /// <summary>Get the Evas object stacked right above <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    Efl.Gfx.IStack Above {
        get ;
    }
}
/// <summary>Efl graphics stack interface
/// (Since EFL 1.22)</summary>
sealed public class IStackConcrete : 

IStack
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IStackConcrete))
                return Efl.Gfx.IStackNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private EventHandlerList eventHandlers = new EventHandlerList();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_gfx_stack_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IStackConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IStackConcrete()
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
    private readonly object eventLock = new object();
    private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 0) {
            IntPtr desc = Efl.EventDescription.GetNative(lib, key);
            if (desc == IntPtr.Zero) {
                Eina.Log.Error($"Failed to get native event {key}");
                return false;
            }
             bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
            if (!result) {
                Eina.Log.Error($"Failed to add event proxy for event {key}");
                return false;
            }
            Eina.Error.RaiseIfUnhandledException();
        } 
        event_cb_count[key]++;
        return true;
    }
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 1) {
            IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
            if (desc == IntPtr.Zero) {
                Eina.Log.Error($"Failed to get native event {key}");
                return false;
            }
            bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
            if (!result) {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return false;
            }
            Eina.Error.RaiseIfUnhandledException();
        } else if (event_count == 0) {
            Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
            return false;
        } 
        event_cb_count[key]--;
        return true;
    }
private static object StackingChangedEvtKey = new object();
    /// <summary>Object stacking was changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler StackingChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_StackingChangedEvt_delegate)) {
                    eventHandlers.AddHandler(StackingChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_StackingChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(StackingChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event StackingChangedEvt.</summary>
    public void On_StackingChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[StackingChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_StackingChangedEvt_delegate;
    private void on_StackingChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_StackingChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_StackingChangedEvt_delegate = new Efl.EventCb(on_StackingChangedEvt_NativeCallback);
    }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
    /// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
    public short GetLayer() {
         var _ret_var = Efl.Gfx.IStackNativeInherit.efl_gfx_stack_layer_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this function, you&apos;ll be dealing with an unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="l">The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</param>
    /// <returns></returns>
    public void SetLayer( short l) {
                                 Efl.Gfx.IStackNativeInherit.efl_gfx_stack_layer_set_ptr.Value.Delegate(this.NativeHandle, l);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public Efl.Gfx.IStack GetBelow() {
         var _ret_var = Efl.Gfx.IStackNativeInherit.efl_gfx_stack_below_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the Evas object stacked right above <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public Efl.Gfx.IStack GetAbove() {
         var _ret_var = Efl.Gfx.IStackNativeInherit.efl_gfx_stack_above_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stack <c>obj</c> immediately <c>below</c>
    /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
    /// 
    /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
    /// 
    /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>below</c> must also be a member of the same smart object.
    /// 
    /// Similarly, if <c>obj</c> is not a member of a smart object, <c>below</c> must not be either.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="below">The object below which to stack</param>
    /// <returns></returns>
    public void StackBelow( Efl.Gfx.IStack below) {
                                 Efl.Gfx.IStackNativeInherit.efl_gfx_stack_below_ptr.Value.Delegate(this.NativeHandle, below);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Raise <c>obj</c> to the top of its layer.
    /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.LowerToBottom"/>
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    public void RaiseToTop() {
         Efl.Gfx.IStackNativeInherit.efl_gfx_stack_raise_to_top_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stack <c>obj</c> immediately <c>above</c>
    /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
    /// 
    /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
    /// 
    /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>above</c> must also be a member of the same smart object.
    /// 
    /// Similarly, if <c>obj</c> is not a member of a smart object, <c>above</c> must not be either.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="above">The object above which to stack</param>
    /// <returns></returns>
    public void StackAbove( Efl.Gfx.IStack above) {
                                 Efl.Gfx.IStackNativeInherit.efl_gfx_stack_above_ptr.Value.Delegate(this.NativeHandle, above);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Lower <c>obj</c> to the bottom of its layer.
    /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.RaiseToTop"/>
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    public void LowerToBottom() {
         Efl.Gfx.IStackNativeInherit.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
/// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
/// (Since EFL 1.22)</summary>
/// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
    public short Layer {
        get { return GetLayer(); }
        set { SetLayer( value); }
    }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Below {
        get { return GetBelow(); }
    }
    /// <summary>Get the Evas object stacked right above <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
/// (Since EFL 1.22)</summary>
/// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Above {
        get { return GetAbove(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IStackConcrete.efl_gfx_stack_interface_get();
    }
}
public class IStackNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_stack_layer_get_static_delegate == null)
            efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLayer") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate)});
        if (efl_gfx_stack_layer_set_static_delegate == null)
            efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLayer") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate)});
        if (efl_gfx_stack_below_get_static_delegate == null)
            efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBelow") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate)});
        if (efl_gfx_stack_above_get_static_delegate == null)
            efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAbove") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate)});
        if (efl_gfx_stack_below_static_delegate == null)
            efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
        if (methods.FirstOrDefault(m => m.Name == "StackBelow") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate)});
        if (efl_gfx_stack_raise_to_top_static_delegate == null)
            efl_gfx_stack_raise_to_top_static_delegate = new efl_gfx_stack_raise_to_top_delegate(raise_to_top);
        if (methods.FirstOrDefault(m => m.Name == "RaiseToTop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_raise_to_top"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_to_top_static_delegate)});
        if (efl_gfx_stack_above_static_delegate == null)
            efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
        if (methods.FirstOrDefault(m => m.Name == "StackAbove") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate)});
        if (efl_gfx_stack_lower_to_bottom_static_delegate == null)
            efl_gfx_stack_lower_to_bottom_static_delegate = new efl_gfx_stack_lower_to_bottom_delegate(lower_to_bottom);
        if (methods.FirstOrDefault(m => m.Name == "LowerToBottom") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_stack_lower_to_bottom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_to_bottom_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IStackConcrete.efl_gfx_stack_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IStackConcrete.efl_gfx_stack_interface_get();
    }


     private delegate short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate short efl_gfx_stack_layer_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate> efl_gfx_stack_layer_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate>(_Module, "efl_gfx_stack_layer_get");
     private static short layer_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_stack_layer_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        short _ret_var = default(short);
            try {
                _ret_var = ((IStack)wrapper).GetLayer();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_stack_layer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;


     private delegate void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,   short l);


     public delegate void efl_gfx_stack_layer_set_api_delegate(System.IntPtr obj,   short l);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate> efl_gfx_stack_layer_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate>(_Module, "efl_gfx_stack_layer_set");
     private static void layer_set(System.IntPtr obj, System.IntPtr pd,  short l)
    {
        Eina.Log.Debug("function efl_gfx_stack_layer_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IStack)wrapper).SetLayer( l);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_stack_layer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l);
        }
    }
    private static efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IStack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IStack efl_gfx_stack_below_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate> efl_gfx_stack_below_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate>(_Module, "efl_gfx_stack_below_get");
     private static Efl.Gfx.IStack below_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_stack_below_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
            try {
                _ret_var = ((IStack)wrapper).GetBelow();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_stack_below_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IStack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IStack efl_gfx_stack_above_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate> efl_gfx_stack_above_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate>(_Module, "efl_gfx_stack_above_get");
     private static Efl.Gfx.IStack above_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_stack_above_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
            try {
                _ret_var = ((IStack)wrapper).GetAbove();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_stack_above_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;


     private delegate void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IStack below);


     public delegate void efl_gfx_stack_below_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IStack below);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate> efl_gfx_stack_below_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate>(_Module, "efl_gfx_stack_below");
     private static void stack_below(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IStack below)
    {
        Eina.Log.Debug("function efl_gfx_stack_below was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IStack)wrapper).StackBelow( below);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_stack_below_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  below);
        }
    }
    private static efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;


     private delegate void efl_gfx_stack_raise_to_top_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_gfx_stack_raise_to_top_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate> efl_gfx_stack_raise_to_top_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate>(_Module, "efl_gfx_stack_raise_to_top");
     private static void raise_to_top(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_stack_raise_to_top was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((IStack)wrapper).RaiseToTop();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_stack_raise_to_top_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_stack_raise_to_top_delegate efl_gfx_stack_raise_to_top_static_delegate;


     private delegate void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IStack above);


     public delegate void efl_gfx_stack_above_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IStackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IStack above);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate> efl_gfx_stack_above_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate>(_Module, "efl_gfx_stack_above");
     private static void stack_above(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IStack above)
    {
        Eina.Log.Debug("function efl_gfx_stack_above was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IStack)wrapper).StackAbove( above);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_stack_above_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  above);
        }
    }
    private static efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;


     private delegate void efl_gfx_stack_lower_to_bottom_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_gfx_stack_lower_to_bottom_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate> efl_gfx_stack_lower_to_bottom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate>(_Module, "efl_gfx_stack_lower_to_bottom");
     private static void lower_to_bottom(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_stack_lower_to_bottom was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((IStack)wrapper).LowerToBottom();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;
}
} } 
