#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Access {

/// <summary>AT-SPI component mixin</summary>
[Efl.Access.IComponentConcrete.NativeMethods]
public interface IComponent : 
    Efl.Gfx.IEntity ,
    Efl.Gfx.IStack ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
/// <returns>Z order of component</returns>
int GetZOrder();
    /// <summary>Geometry of accessible widget.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <returns>The geometry.</returns>
Eina.Rect GetExtents(bool screen_coords);
    /// <summary>Geometry of accessible widget.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="rect">The geometry.</param>
/// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
bool SetExtents(bool screen_coords, Eina.Rect rect);
    /// <summary>Position of accessible widget.</summary>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
void GetScreenPosition(out int x, out int y);
    /// <summary>Position of accessible widget.</summary>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
bool SetScreenPosition(int x, int y);
    /// <summary>Gets position of socket offset.</summary>
void GetSocketOffset(out int x, out int y);
    /// <summary>Sets position of socket offset.</summary>
void SetSocketOffset(int x, int y);
    /// <summary>Contains accessible widget</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
bool Contains(bool screen_coords, int x, int y);
    /// <summary>Focuses accessible widget.</summary>
/// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
bool GrabFocus();
    /// <summary>Gets top component object occupying space at given coordinates.</summary>
/// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <returns>Top component object at given coordinate</returns>
Efl.Object GetAccessibleAtPoint(bool screen_coords, int x, int y);
    /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
/// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
bool GrabHighlight();
    /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
/// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
bool ClearHighlight();
                                                    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    /// <value>Z order of component</value>
    int ZOrder {
        get ;
    }
}
/// <summary>AT-SPI component mixin</summary>
sealed public class IComponentConcrete :
    Efl.Eo.EoWrapper
    , IComponent
    , Efl.Gfx.IEntity, Efl.Gfx.IStack
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IComponentConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_access_component_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IComponent"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IComponentConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> VisibilityChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Gfx.IEntityVisibilityChangedEvt_Args args = new Efl.Gfx.IEntityVisibilityChangedEvt_Args();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event VisibilityChangedEvt.</summary>
    public void OnVisibilityChangedEvt(Efl.Gfx.IEntityVisibilityChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object was moved, its position during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> PositionChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Gfx.IEntityPositionChangedEvt_Args args = new Efl.Gfx.IEntityPositionChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void OnPositionChangedEvt(Efl.Gfx.IEntityPositionChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object was resized, its size during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> SizeChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Gfx.IEntitySizeChangedEvt_Args args = new Efl.Gfx.IEntitySizeChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void OnSizeChangedEvt(Efl.Gfx.IEntitySizeChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object stacking was changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler StackingChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event StackingChangedEvt.</summary>
    public void OnStackingChangedEvt(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    /// <returns>Z order of component</returns>
    public int GetZOrder() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_z_order_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Geometry of accessible widget.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <returns>The geometry.</returns>
    public Eina.Rect GetExtents(bool screen_coords) {
                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_extents_get_ptr.Value.Delegate(this.NativeHandle,screen_coords);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Geometry of accessible widget.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">The geometry.</param>
    /// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
    public bool SetExtents(bool screen_coords, Eina.Rect rect) {
                 Eina.Rect.NativeStruct _in_rect = rect;
                                        var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_extents_set_ptr.Value.Delegate(this.NativeHandle,screen_coords, _in_rect);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Position of accessible widget.</summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public void GetScreenPosition(out int x, out int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_screen_position_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Position of accessible widget.</summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
    public bool SetScreenPosition(int x, int y) {
                                                         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_screen_position_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets position of socket offset.</summary>
    public void GetSocketOffset(out int x, out int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_socket_offset_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets position of socket offset.</summary>
    public void SetSocketOffset(int x, int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_socket_offset_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Contains accessible widget</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
    public bool Contains(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_contains_ptr.Value.Delegate(this.NativeHandle,screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Focuses accessible widget.</summary>
    /// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
    public bool GrabFocus() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_focus_grab_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets top component object occupying space at given coordinates.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Top component object at given coordinate</returns>
    public Efl.Object GetAccessibleAtPoint(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_accessible_at_point_get_ptr.Value.Delegate(this.NativeHandle,screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
    /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
    public bool GrabHighlight() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_highlight_grab_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
    /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
    public bool ClearHighlight() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_highlight_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieves the position of the given canvas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public Eina.Position2D GetPosition() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    public void SetPosition(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate(this.NativeHandle,_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D size in pixel units.</returns>
    public Eina.Size2D GetSize() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
    /// (Since EFL 1.22)</summary>
    /// <param name="size">A 2D size in pixel units.</param>
    public void SetSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate(this.NativeHandle,_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public Eina.Rect GetGeometry() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    public void SetGeometry(Eina.Rect rect) {
         Eina.Rect.NativeStruct _in_rect = rect;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate(this.NativeHandle,_in_rect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given canvas object is visible.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public bool GetVisible() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Shows or hides this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    public void SetVisible(bool v) {
                                 Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate(this.NativeHandle,v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an object&apos;s scaling factor.
    /// (Since EFL 1.22)</summary>
    /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
    public double GetScale() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the scaling factor of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
    public void SetScale(double scale) {
                                 Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate(this.NativeHandle,scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
    /// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
    public short GetLayer() {
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_layer_get_ptr.Value.Delegate(this.NativeHandle);
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
    public void SetLayer(short l) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_layer_set_ptr.Value.Delegate(this.NativeHandle,l);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public Efl.Gfx.IStack GetBelow() {
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_below_get_ptr.Value.Delegate(this.NativeHandle);
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
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_above_get_ptr.Value.Delegate(this.NativeHandle);
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
    public void StackBelow(Efl.Gfx.IStack below) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_below_ptr.Value.Delegate(this.NativeHandle,below);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Raise <c>obj</c> to the top of its layer.
    /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.LowerToBottom"/>
    /// (Since EFL 1.22)</summary>
    public void RaiseToTop() {
         Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_raise_to_top_ptr.Value.Delegate(this.NativeHandle);
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
    public void StackAbove(Efl.Gfx.IStack above) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_above_ptr.Value.Delegate(this.NativeHandle,above);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Lower <c>obj</c> to the bottom of its layer.
    /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.RaiseToTop"/>
    /// (Since EFL 1.22)</summary>
    public void LowerToBottom() {
         Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    /// <value>Z order of component</value>
    public int ZOrder {
        get { return GetZOrder(); }
    }
    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).
    /// (Since EFL 1.22)</summary>
    /// <value>A 2D coordinate in pixel units.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }
    /// <summary>The 2D size of a canvas object.
    /// (Since EFL 1.22)</summary>
    /// <value>A 2D size in pixel units.</value>
    public Eina.Size2D Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    public Eina.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry(value); }
    }
    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible(value); }
    }
    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// (Since EFL 1.22)</summary>
    /// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale(value); }
    }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
    /// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
    public short Layer {
        get { return GetLayer(); }
        set { SetLayer(value); }
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
        return Efl.Access.IComponentConcrete.efl_access_component_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_access_component_z_order_get_static_delegate == null)
            {
                efl_access_component_z_order_get_static_delegate = new efl_access_component_z_order_get_delegate(z_order_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_z_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_z_order_get_static_delegate) });
            }

            if (efl_access_component_extents_get_static_delegate == null)
            {
                efl_access_component_extents_get_static_delegate = new efl_access_component_extents_get_delegate(extents_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_get_static_delegate) });
            }

            if (efl_access_component_extents_set_static_delegate == null)
            {
                efl_access_component_extents_set_static_delegate = new efl_access_component_extents_set_delegate(extents_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_extents_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_set_static_delegate) });
            }

            if (efl_access_component_screen_position_get_static_delegate == null)
            {
                efl_access_component_screen_position_get_static_delegate = new efl_access_component_screen_position_get_delegate(screen_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_screen_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_get_static_delegate) });
            }

            if (efl_access_component_screen_position_set_static_delegate == null)
            {
                efl_access_component_screen_position_set_static_delegate = new efl_access_component_screen_position_set_delegate(screen_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScreenPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_screen_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_set_static_delegate) });
            }

            if (efl_access_component_socket_offset_get_static_delegate == null)
            {
                efl_access_component_socket_offset_get_static_delegate = new efl_access_component_socket_offset_get_delegate(socket_offset_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSocketOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_socket_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_get_static_delegate) });
            }

            if (efl_access_component_socket_offset_set_static_delegate == null)
            {
                efl_access_component_socket_offset_set_static_delegate = new efl_access_component_socket_offset_set_delegate(socket_offset_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSocketOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_socket_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_set_static_delegate) });
            }

            if (efl_access_component_contains_static_delegate == null)
            {
                efl_access_component_contains_static_delegate = new efl_access_component_contains_delegate(contains);
            }

            if (methods.FirstOrDefault(m => m.Name == "Contains") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_contains"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_contains_static_delegate) });
            }

            if (efl_access_component_focus_grab_static_delegate == null)
            {
                efl_access_component_focus_grab_static_delegate = new efl_access_component_focus_grab_delegate(focus_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_focus_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_focus_grab_static_delegate) });
            }

            if (efl_access_component_accessible_at_point_get_static_delegate == null)
            {
                efl_access_component_accessible_at_point_get_static_delegate = new efl_access_component_accessible_at_point_get_delegate(accessible_at_point_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessibleAtPoint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_accessible_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_accessible_at_point_get_static_delegate) });
            }

            if (efl_access_component_highlight_grab_static_delegate == null)
            {
                efl_access_component_highlight_grab_static_delegate = new efl_access_component_highlight_grab_delegate(highlight_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_highlight_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_grab_static_delegate) });
            }

            if (efl_access_component_highlight_clear_static_delegate == null)
            {
                efl_access_component_highlight_clear_static_delegate = new efl_access_component_highlight_clear_delegate(highlight_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_highlight_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_clear_static_delegate) });
            }

            if (efl_gfx_entity_position_get_static_delegate == null)
            {
                efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate) });
            }

            if (efl_gfx_entity_position_set_static_delegate == null)
            {
                efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate) });
            }

            if (efl_gfx_entity_size_get_static_delegate == null)
            {
                efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate) });
            }

            if (efl_gfx_entity_size_set_static_delegate == null)
            {
                efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate) });
            }

            if (efl_gfx_entity_geometry_get_static_delegate == null)
            {
                efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate) });
            }

            if (efl_gfx_entity_geometry_set_static_delegate == null)
            {
                efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate) });
            }

            if (efl_gfx_entity_visible_get_static_delegate == null)
            {
                efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate) });
            }

            if (efl_gfx_entity_visible_set_static_delegate == null)
            {
                efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate) });
            }

            if (efl_gfx_entity_scale_get_static_delegate == null)
            {
                efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate) });
            }

            if (efl_gfx_entity_scale_set_static_delegate == null)
            {
                efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate) });
            }

            if (efl_gfx_stack_layer_get_static_delegate == null)
            {
                efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLayer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate) });
            }

            if (efl_gfx_stack_layer_set_static_delegate == null)
            {
                efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLayer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate) });
            }

            if (efl_gfx_stack_below_get_static_delegate == null)
            {
                efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBelow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate) });
            }

            if (efl_gfx_stack_above_get_static_delegate == null)
            {
                efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAbove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate) });
            }

            if (efl_gfx_stack_below_static_delegate == null)
            {
                efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
            }

            if (methods.FirstOrDefault(m => m.Name == "StackBelow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate) });
            }

            if (efl_gfx_stack_raise_to_top_static_delegate == null)
            {
                efl_gfx_stack_raise_to_top_static_delegate = new efl_gfx_stack_raise_to_top_delegate(raise_to_top);
            }

            if (methods.FirstOrDefault(m => m.Name == "RaiseToTop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_raise_to_top"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_to_top_static_delegate) });
            }

            if (efl_gfx_stack_above_static_delegate == null)
            {
                efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
            }

            if (methods.FirstOrDefault(m => m.Name == "StackAbove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate) });
            }

            if (efl_gfx_stack_lower_to_bottom_static_delegate == null)
            {
                efl_gfx_stack_lower_to_bottom_static_delegate = new efl_gfx_stack_lower_to_bottom_delegate(lower_to_bottom);
            }

            if (methods.FirstOrDefault(m => m.Name == "LowerToBottom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_lower_to_bottom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_to_bottom_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Access.IComponentConcrete.efl_access_component_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_access_component_z_order_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_component_z_order_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate> efl_access_component_z_order_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate>(Module, "efl_access_component_z_order_get");

        private static int z_order_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_z_order_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetZOrder();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_access_component_z_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_z_order_get_delegate efl_access_component_z_order_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_access_component_extents_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords);

        
        public delegate Eina.Rect.NativeStruct efl_access_component_extents_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords);

        public static Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate> efl_access_component_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate>(Module, "efl_access_component_extents_get");

        private static Eina.Rect.NativeStruct extents_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords)
        {
            Eina.Log.Debug("function efl_access_component_extents_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetExtents(screen_coords);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_access_component_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords);
            }
        }

        private static efl_access_component_extents_get_delegate efl_access_component_extents_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_extents_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_extents_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate> efl_access_component_extents_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate>(Module, "efl_access_component_extents_set");

        private static bool extents_set(System.IntPtr obj, System.IntPtr pd, bool screen_coords, Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_access_component_extents_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_rect = rect;
                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).SetExtents(screen_coords, _in_rect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var;

            }
            else
            {
                return efl_access_component_extents_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, rect);
            }
        }

        private static efl_access_component_extents_set_delegate efl_access_component_extents_set_static_delegate;

        
        private delegate void efl_access_component_screen_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int x,  out int y);

        
        public delegate void efl_access_component_screen_position_get_api_delegate(System.IntPtr obj,  out int x,  out int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate> efl_access_component_screen_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate>(Module, "efl_access_component_screen_position_get");

        private static void screen_position_get(System.IntPtr obj, System.IntPtr pd, out int x, out int y)
        {
            Eina.Log.Debug("function efl_access_component_screen_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(int);        y = default(int);                            
                try
                {
                    ((IComponent)ws.Target).GetScreenPosition(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_screen_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_access_component_screen_position_get_delegate efl_access_component_screen_position_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_screen_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  int x,  int y);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_screen_position_set_api_delegate(System.IntPtr obj,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate> efl_access_component_screen_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate>(Module, "efl_access_component_screen_position_set");

        private static bool screen_position_set(System.IntPtr obj, System.IntPtr pd, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_screen_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).SetScreenPosition(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var;

            }
            else
            {
                return efl_access_component_screen_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_access_component_screen_position_set_delegate efl_access_component_screen_position_set_static_delegate;

        
        private delegate void efl_access_component_socket_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int x,  out int y);

        
        public delegate void efl_access_component_socket_offset_get_api_delegate(System.IntPtr obj,  out int x,  out int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate> efl_access_component_socket_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate>(Module, "efl_access_component_socket_offset_get");

        private static void socket_offset_get(System.IntPtr obj, System.IntPtr pd, out int x, out int y)
        {
            Eina.Log.Debug("function efl_access_component_socket_offset_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(int);        y = default(int);                            
                try
                {
                    ((IComponent)ws.Target).GetSocketOffset(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_socket_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_access_component_socket_offset_get_delegate efl_access_component_socket_offset_get_static_delegate;

        
        private delegate void efl_access_component_socket_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  int x,  int y);

        
        public delegate void efl_access_component_socket_offset_set_api_delegate(System.IntPtr obj,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate> efl_access_component_socket_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate>(Module, "efl_access_component_socket_offset_set");

        private static void socket_offset_set(System.IntPtr obj, System.IntPtr pd, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_socket_offset_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IComponent)ws.Target).SetSocketOffset(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_socket_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_access_component_socket_offset_set_delegate efl_access_component_socket_offset_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_contains_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_contains_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate> efl_access_component_contains_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate>(Module, "efl_access_component_contains");

        private static bool contains(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_contains was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).Contains(screen_coords, x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        return _ret_var;

            }
            else
            {
                return efl_access_component_contains_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, x, y);
            }
        }

        private static efl_access_component_contains_delegate efl_access_component_contains_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_focus_grab_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_focus_grab_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate> efl_access_component_focus_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate>(Module, "efl_access_component_focus_grab");

        private static bool focus_grab(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_focus_grab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GrabFocus();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_access_component_focus_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_focus_grab_delegate efl_access_component_focus_grab_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_component_accessible_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_component_accessible_at_point_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate> efl_access_component_accessible_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate>(Module, "efl_access_component_accessible_at_point_get");

        private static Efl.Object accessible_at_point_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_accessible_at_point_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetAccessibleAtPoint(screen_coords, x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        return _ret_var;

            }
            else
            {
                return efl_access_component_accessible_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, x, y);
            }
        }

        private static efl_access_component_accessible_at_point_get_delegate efl_access_component_accessible_at_point_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_highlight_grab_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_highlight_grab_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate> efl_access_component_highlight_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate>(Module, "efl_access_component_highlight_grab");

        private static bool highlight_grab(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_highlight_grab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GrabHighlight();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_access_component_highlight_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_highlight_grab_delegate efl_access_component_highlight_grab_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_highlight_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_highlight_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate> efl_access_component_highlight_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate>(Module, "efl_access_component_highlight_clear");

        private static bool highlight_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_highlight_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).ClearHighlight();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_access_component_highlight_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_highlight_clear_delegate efl_access_component_highlight_clear_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(Module, "efl_gfx_entity_position_get");

        private static Eina.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetPosition();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_entity_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;

        
        private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(Module, "efl_gfx_entity_position_set");

        private static void position_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_gfx_entity_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            
                try
                {
                    ((IComponent)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(Module, "efl_gfx_entity_size_get");

        private static Eina.Size2D.NativeStruct size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetSize();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_entity_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;

        
        private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(Module, "efl_gfx_entity_size_set");

        private static void size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_entity_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((IComponent)ws.Target).SetSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(Module, "efl_gfx_entity_geometry_get");

        private static Eina.Rect.NativeStruct geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetGeometry();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_entity_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;

        
        private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect);

        
        public delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(Module, "efl_gfx_entity_geometry_set");

        private static void geometry_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_gfx_entity_geometry_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                            
                try
                {
                    ((IComponent)ws.Target).SetGeometry(_in_rect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_geometry_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect);
            }
        }

        private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(Module, "efl_gfx_entity_visible_get");

        private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_visible_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetVisible();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_entity_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;

        
        private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(Module, "efl_gfx_entity_visible_set");

        private static void visible_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            Eina.Log.Debug("function efl_gfx_entity_visible_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IComponent)ws.Target).SetVisible(v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), v);
            }
        }

        private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;

        
        private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(Module, "efl_gfx_entity_scale_get");

        private static double scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_scale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetScale();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_entity_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;

        
        private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        public delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,  double scale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(Module, "efl_gfx_entity_scale_set");

        private static void scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            Eina.Log.Debug("function efl_gfx_entity_scale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IComponent)ws.Target).SetScale(scale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scale);
            }
        }

        private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;

        
        private delegate short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate short efl_gfx_stack_layer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate> efl_gfx_stack_layer_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate>(Module, "efl_gfx_stack_layer_get");

        private static short layer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_layer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            short _ret_var = default(short);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetLayer();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_stack_layer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;

        
        private delegate void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,  short l);

        
        public delegate void efl_gfx_stack_layer_set_api_delegate(System.IntPtr obj,  short l);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate> efl_gfx_stack_layer_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate>(Module, "efl_gfx_stack_layer_set");

        private static void layer_set(System.IntPtr obj, System.IntPtr pd, short l)
        {
            Eina.Log.Debug("function efl_gfx_stack_layer_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IComponent)ws.Target).SetLayer(l);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_layer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), l);
            }
        }

        private static efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IStack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IStack efl_gfx_stack_below_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate> efl_gfx_stack_below_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate>(Module, "efl_gfx_stack_below_get");

        private static Efl.Gfx.IStack below_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_below_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetBelow();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_stack_below_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IStack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IStack efl_gfx_stack_above_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate> efl_gfx_stack_above_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate>(Module, "efl_gfx_stack_above_get");

        private static Efl.Gfx.IStack above_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_above_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
                try
                {
                    _ret_var = ((IComponent)ws.Target).GetAbove();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_stack_above_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;

        
        private delegate void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack below);

        
        public delegate void efl_gfx_stack_below_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack below);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate> efl_gfx_stack_below_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate>(Module, "efl_gfx_stack_below");

        private static void stack_below(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IStack below)
        {
            Eina.Log.Debug("function efl_gfx_stack_below was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IComponent)ws.Target).StackBelow(below);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_below_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), below);
            }
        }

        private static efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;

        
        private delegate void efl_gfx_stack_raise_to_top_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_stack_raise_to_top_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate> efl_gfx_stack_raise_to_top_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate>(Module, "efl_gfx_stack_raise_to_top");

        private static void raise_to_top(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_raise_to_top was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IComponent)ws.Target).RaiseToTop();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_stack_raise_to_top_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_raise_to_top_delegate efl_gfx_stack_raise_to_top_static_delegate;

        
        private delegate void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack above);

        
        public delegate void efl_gfx_stack_above_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack above);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate> efl_gfx_stack_above_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate>(Module, "efl_gfx_stack_above");

        private static void stack_above(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IStack above)
        {
            Eina.Log.Debug("function efl_gfx_stack_above was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IComponent)ws.Target).StackAbove(above);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_above_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), above);
            }
        }

        private static efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;

        
        private delegate void efl_gfx_stack_lower_to_bottom_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_stack_lower_to_bottom_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate> efl_gfx_stack_lower_to_bottom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate>(Module, "efl_gfx_stack_lower_to_bottom");

        private static void lower_to_bottom(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_lower_to_bottom was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IComponent)ws.Target).LowerToBottom();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

