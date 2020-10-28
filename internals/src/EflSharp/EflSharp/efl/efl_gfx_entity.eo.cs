#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics interface
/// (Since EFL 1.22)</summary>
[IEntityNativeInherit]
public interface IEntity : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Retrieves the position of the given canvas object.
/// (Since EFL 1.22)</summary>
/// <returns>A 2D coordinate in pixel units.</returns>
Eina.Position2D GetPosition();
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
/// (Since EFL 1.22)</summary>
/// <param name="pos">A 2D coordinate in pixel units.</param>
/// <returns></returns>
void SetPosition( Eina.Position2D pos);
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
/// (Since EFL 1.22)</summary>
/// <returns>A 2D size in pixel units.</returns>
Eina.Size2D GetSize();
    /// <summary>Changes the size of the given object.
/// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
/// (Since EFL 1.22)</summary>
/// <param name="size">A 2D size in pixel units.</param>
/// <returns></returns>
void SetSize( Eina.Size2D size);
    /// <summary>Rectangular geometry that combines both position and size.
/// (Since EFL 1.22)</summary>
/// <returns>The X,Y position and W,H size, in pixels.</returns>
Eina.Rect GetGeometry();
    /// <summary>Rectangular geometry that combines both position and size.
/// (Since EFL 1.22)</summary>
/// <param name="rect">The X,Y position and W,H size, in pixels.</param>
/// <returns></returns>
void SetGeometry( Eina.Rect rect);
    /// <summary>Retrieves whether or not the given canvas object is visible.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
bool GetVisible();
    /// <summary>Shows or hides this object.
/// (Since EFL 1.22)</summary>
/// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
/// <returns></returns>
void SetVisible( bool v);
    /// <summary>Gets an object&apos;s scaling factor.
/// (Since EFL 1.22)</summary>
/// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
double GetScale();
    /// <summary>Sets the scaling factor of an object.
/// (Since EFL 1.22)</summary>
/// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
/// <returns></returns>
void SetScale( double scale);
                                            /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> VisibilityChangedEvt;
    /// <summary>Object was moved, its position during the event is the new one.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> PositionChangedEvt;
    /// <summary>Object was resized, its size during the event is the new one.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> SizeChangedEvt;
    /// <summary>The 2D position of a canvas object.
/// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).
/// (Since EFL 1.22)</summary>
/// <value>A 2D coordinate in pixel units.</value>
    Eina.Position2D Position {
        get ;
        set ;
    }
    /// <summary>The 2D size of a canvas object.
/// (Since EFL 1.22)</summary>
/// <value>A 2D size in pixel units.</value>
    Eina.Size2D Size {
        get ;
        set ;
    }
    /// <summary>Rectangular geometry that combines both position and size.
/// (Since EFL 1.22)</summary>
/// <value>The X,Y position and W,H size, in pixels.</value>
    Eina.Rect Geometry {
        get ;
        set ;
    }
    /// <summary>The visibility of a canvas object.
/// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
/// 
/// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    bool Visible {
        get ;
        set ;
    }
    /// <summary>The scaling factor of an object.
/// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
/// 
/// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.
/// (Since EFL 1.22)</summary>
/// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
    double Scale {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gfx.IEntity.VisibilityChangedEvt"/>.</summary>
public class IEntityVisibilityChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gfx.IEntity.PositionChangedEvt"/>.</summary>
public class IEntityPositionChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Eina.Position2D arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gfx.IEntity.SizeChangedEvt"/>.</summary>
public class IEntitySizeChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Eina.Size2D arg { get; set; }
}
/// <summary>Efl graphics interface
/// (Since EFL 1.22)</summary>
sealed public class IEntityConcrete : 

IEntity
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IEntityConcrete))
                return Efl.Gfx.IEntityNativeInherit.GetEflClassStatic();
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
        efl_gfx_entity_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IEntityConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IEntityConcrete()
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
private static object VisibilityChangedEvtKey = new object();
    /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> VisibilityChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_VisibilityChangedEvt_delegate)) {
                    eventHandlers.AddHandler(VisibilityChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_VisibilityChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(VisibilityChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event VisibilityChangedEvt.</summary>
    public void On_VisibilityChangedEvt(Efl.Gfx.IEntityVisibilityChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args>)eventHandlers[VisibilityChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_VisibilityChangedEvt_delegate;
    private void on_VisibilityChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntityVisibilityChangedEvt_Args args = new Efl.Gfx.IEntityVisibilityChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_VisibilityChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PositionChangedEvtKey = new object();
    /// <summary>Object was moved, its position during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> PositionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void On_PositionChangedEvt(Efl.Gfx.IEntityPositionChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args>)eventHandlers[PositionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionChangedEvt_delegate;
    private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntityPositionChangedEvt_Args args = new Efl.Gfx.IEntityPositionChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_PositionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SizeChangedEvtKey = new object();
    /// <summary>Object was resized, its size during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> SizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void On_SizeChangedEvt(Efl.Gfx.IEntitySizeChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args>)eventHandlers[SizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SizeChangedEvt_delegate;
    private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntitySizeChangedEvt_Args args = new Efl.Gfx.IEntitySizeChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_SizeChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_VisibilityChangedEvt_delegate = new Efl.EventCb(on_VisibilityChangedEvt_NativeCallback);
        evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
        evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
    }
    /// <summary>Retrieves the position of the given canvas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public Eina.Position2D GetPosition() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_position_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    /// <returns></returns>
    public void SetPosition( Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_position_set_ptr.Value.Delegate(this.NativeHandle, _in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D size in pixel units.</returns>
    public Eina.Size2D GetSize() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
    /// (Since EFL 1.22)</summary>
    /// <param name="size">A 2D size in pixel units.</param>
    /// <returns></returns>
    public void SetSize( Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_size_set_ptr.Value.Delegate(this.NativeHandle, _in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public Eina.Rect GetGeometry() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    /// <returns></returns>
    public void SetGeometry( Eina.Rect rect) {
         Eina.Rect.NativeStruct _in_rect = rect;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_geometry_set_ptr.Value.Delegate(this.NativeHandle, _in_rect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given canvas object is visible.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public bool GetVisible() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_visible_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Shows or hides this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    /// <returns></returns>
    public void SetVisible( bool v) {
                                 Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_visible_set_ptr.Value.Delegate(this.NativeHandle, v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an object&apos;s scaling factor.
    /// (Since EFL 1.22)</summary>
    /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
    public double GetScale() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_scale_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the scaling factor of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
    /// <returns></returns>
    public void SetScale( double scale) {
                                 Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_scale_set_ptr.Value.Delegate(this.NativeHandle, scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The 2D position of a canvas object.
/// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).
/// (Since EFL 1.22)</summary>
/// <value>A 2D coordinate in pixel units.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition( value); }
    }
    /// <summary>The 2D size of a canvas object.
/// (Since EFL 1.22)</summary>
/// <value>A 2D size in pixel units.</value>
    public Eina.Size2D Size {
        get { return GetSize(); }
        set { SetSize( value); }
    }
    /// <summary>Rectangular geometry that combines both position and size.
/// (Since EFL 1.22)</summary>
/// <value>The X,Y position and W,H size, in pixels.</value>
    public Eina.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry( value); }
    }
    /// <summary>The visibility of a canvas object.
/// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
/// 
/// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible( value); }
    }
    /// <summary>The scaling factor of an object.
/// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
/// 
/// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.
/// (Since EFL 1.22)</summary>
/// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IEntityConcrete.efl_gfx_entity_interface_get();
    }
}
public class IEntityNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_entity_position_get_static_delegate == null)
            efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate)});
        if (efl_gfx_entity_position_set_static_delegate == null)
            efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate)});
        if (efl_gfx_entity_size_get_static_delegate == null)
            efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate)});
        if (efl_gfx_entity_size_set_static_delegate == null)
            efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate)});
        if (efl_gfx_entity_geometry_get_static_delegate == null)
            efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate)});
        if (efl_gfx_entity_geometry_set_static_delegate == null)
            efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate)});
        if (efl_gfx_entity_visible_get_static_delegate == null)
            efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
        if (methods.FirstOrDefault(m => m.Name == "GetVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate)});
        if (efl_gfx_entity_visible_set_static_delegate == null)
            efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
        if (methods.FirstOrDefault(m => m.Name == "SetVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate)});
        if (efl_gfx_entity_scale_get_static_delegate == null)
            efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate)});
        if (efl_gfx_entity_scale_set_static_delegate == null)
            efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IEntityConcrete.efl_gfx_entity_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IEntityConcrete.efl_gfx_entity_interface_get();
    }


     private delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(_Module, "efl_gfx_entity_position_get");
     private static Eina.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((IEntity)wrapper).GetPosition();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;


     private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct pos);


     public delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct pos);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(_Module, "efl_gfx_entity_position_set");
     private static void position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos)
    {
        Eina.Log.Debug("function efl_gfx_entity_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_pos = pos;
                            
            try {
                ((IEntity)wrapper).SetPosition( _in_pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
        }
    }
    private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(_Module, "efl_gfx_entity_size_get");
     private static Eina.Size2D.NativeStruct size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((IEntity)wrapper).GetSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;


     private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct size);


     public delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct size);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(_Module, "efl_gfx_entity_size_set");
     private static void size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size)
    {
        Eina.Log.Debug("function efl_gfx_entity_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_size = size;
                            
            try {
                ((IEntity)wrapper).SetSize( _in_size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(_Module, "efl_gfx_entity_geometry_get");
     private static Eina.Rect.NativeStruct geometry_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((IEntity)wrapper).GetGeometry();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;


     private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct rect);


     public delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct rect);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(_Module, "efl_gfx_entity_geometry_set");
     private static void geometry_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect)
    {
        Eina.Log.Debug("function efl_gfx_entity_geometry_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_rect = rect;
                            
            try {
                ((IEntity)wrapper).SetGeometry( _in_rect);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_geometry_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect);
        }
    }
    private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(_Module, "efl_gfx_entity_visible_get");
     private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_visible_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IEntity)wrapper).GetVisible();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;


     private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool v);


     public delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(_Module, "efl_gfx_entity_visible_set");
     private static void visible_set(System.IntPtr obj, System.IntPtr pd,  bool v)
    {
        Eina.Log.Debug("function efl_gfx_entity_visible_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IEntity)wrapper).SetVisible( v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  v);
        }
    }
    private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;


     private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(_Module, "efl_gfx_entity_scale_get");
     private static double scale_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_scale_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IEntity)wrapper).GetScale();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;


     private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);


     public delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,   double scale);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(_Module, "efl_gfx_entity_scale_set");
     private static void scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
    {
        Eina.Log.Debug("function efl_gfx_entity_scale_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IEntity)wrapper).SetScale( scale);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
        }
    }
    private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;
}
} } 
