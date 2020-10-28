#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Interface containing basic canvas-related methods and events.
/// (Since EFL 1.22)</summary>
[Efl.Canvas.ISceneConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IScene : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the maximum image size the canvas can possibly handle.
/// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
/// 
/// The default limit is 65535x65535.
/// (Since EFL 1.22)</summary>
/// <param name="max">The maximum image size (in pixels).</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetImageMaxSize(out Eina.Size2D max);
    /// <summary>Get if the canvas is currently calculating group objects.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if currently calculating group objects.</returns>
bool GetGroupObjectsCalculating();
    /// <summary>Get a device by name.
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="name">The name of the seat to find.</param>
/// <returns>The device or seat, <c>null</c> if not found.</returns>
Efl.Input.Device GetDevice(System.String name);
    /// <summary>Get a seat by id.
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="id">The id of the seat to find.</param>
/// <returns>The seat or <c>null</c> if not found.</returns>
Efl.Input.Device GetSeat(int id);
    /// <summary>Get the default seat.
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <returns>The default seat or <c>null</c> if one does not exist.</returns>
Efl.Input.Device GetSeatDefault();
    /// <summary>This function returns the current known pointer coordinates
/// This function returns the current position of the main input pointer (mouse, pen, etc...).
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="seat">The seat, or <c>null</c> to use the default.</param>
/// <param name="pos">The pointer position in pixels.</param>
/// <returns><c>true</c> if a pointer exists for the given seat, otherwise <c>false</c>.</returns>
bool GetPointerPosition(Efl.Input.Device seat, out Eina.Position2D pos);
    /// <summary>Call user-provided <c>calculate</c> group functions and unset the flag signalling that the object needs to get recalculated to all group objects in the canvas.
/// (Since EFL 1.22)</summary>
void CalculateGroupObjects();
    /// <summary>Retrieve a list of objects at a given position in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
/// (Since EFL 1.22)</summary>
/// <param name="pos">The pixel position.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
Eina.Iterator<Efl.Gfx.IEntity> GetObjectsAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects);
    /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
/// (Since EFL 1.22)</summary>
/// <param name="pos">The pixel position.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The canvas object that is over all other objects at the given position.</returns>
Efl.Gfx.IEntity GetObjectTopAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects);
    /// <summary>Retrieve a list of objects overlapping a given rectangular region in a canvas.
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
/// (Since EFL 1.22)</summary>
/// <param name="rect">The rectangular region.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>Iterator to objects</returns>
Eina.Iterator<Efl.Gfx.IEntity> GetObjectsInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects);
    /// <summary>Retrieve the canvas object stacked at the top of a given rectangular region in a canvas
/// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
/// 
/// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
/// (Since EFL 1.22)</summary>
/// <param name="rect">The rectangular region.</param>
/// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
/// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
/// <returns>The object that is over all other objects at the given rectangular region.</returns>
Efl.Gfx.IEntity GetObjectTopInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects);
    /// <summary>Iterate over the available input device seats for the canvas.
/// A &quot;seat&quot; is the term used for a group of input devices, typically including a pointer and a keyboard. A seat object is the parent of the individual input devices.
/// (Since EFL 1.22)
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <returns>An iterator over the attached seats.</returns>
Eina.Iterator<Efl.Input.Device> Seats();
                                                    /// <summary>Called when scene got focus
    /// (Since EFL 1.22)</summary>
    event EventHandler SceneFocusInEvt;
    /// <summary>Called when scene lost focus
    /// (Since EFL 1.22)</summary>
    event EventHandler SceneFocusOutEvt;
    /// <summary>Called when object got focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneObjectFocusInEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneObjectFocusInEvt_Args> ObjectFocusInEvt;
    /// <summary>Called when object lost focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneObjectFocusOutEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneObjectFocusOutEvt_Args> ObjectFocusOutEvt;
    /// <summary>Called when pre render happens
    /// (Since EFL 1.22)</summary>
    event EventHandler RenderPreEvt;
    /// <summary>Called when post render happens
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneRenderPostEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneRenderPostEvt_Args> RenderPostEvt;
    /// <summary>Called when input device changed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceChangedEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneDeviceChangedEvt_Args> DeviceChangedEvt;
    /// <summary>Called when input device was added
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceAddedEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneDeviceAddedEvt_Args> DeviceAddedEvt;
    /// <summary>Called when input device was removed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceRemovedEvt_Args"/></value>
    event EventHandler<Efl.Canvas.ISceneDeviceRemovedEvt_Args> DeviceRemovedEvt;
    /// <summary>Get the maximum image size the canvas can possibly handle.
    /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
    /// 
    /// The default limit is 65535x65535.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> on success, <c>false</c> otherwise</value>
    Eina.Size2D ImageMaxSize {
        get;
    }
    /// <summary>Get if the canvas is currently calculating group objects.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if currently calculating group objects.</value>
    bool GroupObjectsCalculating {
        get;
    }
    /// <summary>Get the default seat attached to this canvas.
    /// A canvas may have exactly one default seat.
    /// 
    /// See also <see cref="Efl.Canvas.IScene.GetDevice"/> to find a seat by name. See also <see cref="Efl.Canvas.IScene.GetSeat"/> to find a seat by id.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <value>The default seat or <c>null</c> if one does not exist.</value>
    Efl.Input.Device SeatDefault {
        get;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.ObjectFocusInEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneObjectFocusInEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when object got focus</value>
    public Efl.Input.Focus arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.ObjectFocusOutEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneObjectFocusOutEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when object lost focus</value>
    public Efl.Input.Focus arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.RenderPostEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneRenderPostEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when post render happens</value>
    public Efl.Gfx.Event.RenderPost arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.DeviceChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneDeviceChangedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when input device changed</value>
    public Efl.Input.Device arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.DeviceAddedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneDeviceAddedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when input device was added</value>
    public Efl.Input.Device arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.IScene.DeviceRemovedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ISceneDeviceRemovedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when input device was removed</value>
    public Efl.Input.Device arg { get; set; }
}
/// <summary>Interface containing basic canvas-related methods and events.
/// (Since EFL 1.22)</summary>
sealed public  class ISceneConcrete :
    Efl.Eo.EoWrapper
    , IScene
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ISceneConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ISceneConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_canvas_scene_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IScene"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ISceneConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when scene got focus
    /// (Since EFL 1.22)</summary>
    public event EventHandler SceneFocusInEvt
    {
        add
        {
            lock (eflBindingEventLock)
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

                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event SceneFocusInEvt.</summary>
    public void OnSceneFocusInEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scene lost focus
    /// (Since EFL 1.22)</summary>
    public event EventHandler SceneFocusOutEvt
    {
        add
        {
            lock (eflBindingEventLock)
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

                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event SceneFocusOutEvt.</summary>
    public void OnSceneFocusOutEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object got focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneObjectFocusInEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneObjectFocusInEvt_Args> ObjectFocusInEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneObjectFocusInEvt_Args args = new Efl.Canvas.ISceneObjectFocusInEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ObjectFocusInEvt.</summary>
    public void OnObjectFocusInEvt(Efl.Canvas.ISceneObjectFocusInEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when object lost focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneObjectFocusOutEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneObjectFocusOutEvt_Args> ObjectFocusOutEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneObjectFocusOutEvt_Args args = new Efl.Canvas.ISceneObjectFocusOutEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ObjectFocusOutEvt.</summary>
    public void OnObjectFocusOutEvt(Efl.Canvas.ISceneObjectFocusOutEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when pre render happens
    /// (Since EFL 1.22)</summary>
    public event EventHandler RenderPreEvt
    {
        add
        {
            lock (eflBindingEventLock)
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

                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event RenderPreEvt.</summary>
    public void OnRenderPreEvt(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when post render happens
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneRenderPostEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneRenderPostEvt_Args> RenderPostEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneRenderPostEvt_Args args = new Efl.Canvas.ISceneRenderPostEvt_Args();
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

                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event RenderPostEvt.</summary>
    public void OnRenderPostEvt(Efl.Canvas.ISceneRenderPostEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Called when input device changed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceChangedEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneDeviceChangedEvt_Args> DeviceChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneDeviceChangedEvt_Args args = new Efl.Canvas.ISceneDeviceChangedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceChangedEvt.</summary>
    public void OnDeviceChangedEvt(Efl.Canvas.ISceneDeviceChangedEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when input device was added
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceAddedEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneDeviceAddedEvt_Args> DeviceAddedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneDeviceAddedEvt_Args args = new Efl.Canvas.ISceneDeviceAddedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceAddedEvt.</summary>
    public void OnDeviceAddedEvt(Efl.Canvas.ISceneDeviceAddedEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when input device was removed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ISceneDeviceRemovedEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ISceneDeviceRemovedEvt_Args> DeviceRemovedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Canvas.ISceneDeviceRemovedEvt_Args args = new Efl.Canvas.ISceneDeviceRemovedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceRemovedEvt.</summary>
    public void OnDeviceRemovedEvt(Efl.Canvas.ISceneDeviceRemovedEvt_Args e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Get the maximum image size the canvas can possibly handle.
    /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
    /// 
    /// The default limit is 65535x65535.
    /// (Since EFL 1.22)</summary>
    /// <param name="max">The maximum image size (in pixels).</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool GetImageMaxSize(out Eina.Size2D max) {
                 var _out_max = new Eina.Size2D.NativeStruct();
                var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_image_max_size_get_ptr.Value.Delegate(this.NativeHandle,out _out_max);
        Eina.Error.RaiseIfUnhandledException();
        max = _out_max;
                return _ret_var;
 }
    /// <summary>Get if the canvas is currently calculating group objects.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if currently calculating group objects.</returns>
    public bool GetGroupObjectsCalculating() {
         var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_group_objects_calculating_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get a device by name.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="name">The name of the seat to find.</param>
    /// <returns>The device or seat, <c>null</c> if not found.</returns>
    public Efl.Input.Device GetDevice(System.String name) {
                                 var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_device_get_ptr.Value.Delegate(this.NativeHandle,name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get a seat by id.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="id">The id of the seat to find.</param>
    /// <returns>The seat or <c>null</c> if not found.</returns>
    public Efl.Input.Device GetSeat(int id) {
                                 var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_seat_get_ptr.Value.Delegate(this.NativeHandle,id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the default seat.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>The default seat or <c>null</c> if one does not exist.</returns>
    public Efl.Input.Device GetSeatDefault() {
         var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_seat_default_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This function returns the current known pointer coordinates
    /// This function returns the current position of the main input pointer (mouse, pen, etc...).
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat, or <c>null</c> to use the default.</param>
    /// <param name="pos">The pointer position in pixels.</param>
    /// <returns><c>true</c> if a pointer exists for the given seat, otherwise <c>false</c>.</returns>
    public bool GetPointerPosition(Efl.Input.Device seat, out Eina.Position2D pos) {
                                 var _out_pos = new Eina.Position2D.NativeStruct();
                        var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_pointer_position_get_ptr.Value.Delegate(this.NativeHandle,seat, out _out_pos);
        Eina.Error.RaiseIfUnhandledException();
                pos = _out_pos;
                        return _ret_var;
 }
    /// <summary>Call user-provided <c>calculate</c> group functions and unset the flag signalling that the object needs to get recalculated to all group objects in the canvas.
    /// (Since EFL 1.22)</summary>
    public void CalculateGroupObjects() {
         Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_group_objects_calculate_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Retrieve a list of objects at a given position in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">The pixel position.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
    public Eina.Iterator<Efl.Gfx.IEntity> GetObjectsAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                                                                        var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_objects_at_xy_get_ptr.Value.Delegate(this.NativeHandle,_in_pos, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">The pixel position.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The canvas object that is over all other objects at the given position.</returns>
    public Efl.Gfx.IEntity GetObjectTopAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                                                                        var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_object_top_at_xy_get_ptr.Value.Delegate(this.NativeHandle,_in_pos, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Retrieve a list of objects overlapping a given rectangular region in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The rectangular region.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>Iterator to objects</returns>
    public Eina.Iterator<Efl.Gfx.IEntity> GetObjectsInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                                        var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_objects_in_rectangle_get_ptr.Value.Delegate(this.NativeHandle,_in_rect, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Retrieve the canvas object stacked at the top of a given rectangular region in a canvas
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The rectangular region.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The object that is over all other objects at the given rectangular region.</returns>
    public Efl.Gfx.IEntity GetObjectTopInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                                        var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_object_top_in_rectangle_get_ptr.Value.Delegate(this.NativeHandle,_in_rect, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Iterate over the available input device seats for the canvas.
    /// A &quot;seat&quot; is the term used for a group of input devices, typically including a pointer and a keyboard. A seat object is the parent of the individual input devices.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>An iterator over the attached seats.</returns>
    public Eina.Iterator<Efl.Input.Device> Seats() {
         var _ret_var = Efl.Canvas.ISceneConcrete.NativeMethods.efl_canvas_scene_seats_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Input.Device>(_ret_var, true);
 }
    /// <summary>Get the maximum image size the canvas can possibly handle.
    /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
    /// 
    /// The default limit is 65535x65535.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> on success, <c>false</c> otherwise</value>
    public Eina.Size2D ImageMaxSize {
        get {
            Eina.Size2D _out_max = default(Eina.Size2D);
            GetImageMaxSize(out _out_max);
            return (_out_max);
        }
    }
    /// <summary>Get if the canvas is currently calculating group objects.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if currently calculating group objects.</value>
    public bool GroupObjectsCalculating {
        get { return GetGroupObjectsCalculating(); }
    }
    /// <summary>Get the default seat attached to this canvas.
    /// A canvas may have exactly one default seat.
    /// 
    /// See also <see cref="Efl.Canvas.IScene.GetDevice"/> to find a seat by name. See also <see cref="Efl.Canvas.IScene.GetSeat"/> to find a seat by id.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <value>The default seat or <c>null</c> if one does not exist.</value>
    public Efl.Input.Device SeatDefault {
        get { return GetSeatDefault(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.ISceneConcrete.efl_canvas_scene_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_scene_image_max_size_get_static_delegate == null)
            {
                efl_canvas_scene_image_max_size_get_static_delegate = new efl_canvas_scene_image_max_size_get_delegate(image_max_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageMaxSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_image_max_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_image_max_size_get_static_delegate) });
            }

            if (efl_canvas_scene_group_objects_calculating_get_static_delegate == null)
            {
                efl_canvas_scene_group_objects_calculating_get_static_delegate = new efl_canvas_scene_group_objects_calculating_get_delegate(group_objects_calculating_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupObjectsCalculating") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_group_objects_calculating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_group_objects_calculating_get_static_delegate) });
            }

            if (efl_canvas_scene_device_get_static_delegate == null)
            {
                efl_canvas_scene_device_get_static_delegate = new efl_canvas_scene_device_get_delegate(device_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDevice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_device_get_static_delegate) });
            }

            if (efl_canvas_scene_seat_get_static_delegate == null)
            {
                efl_canvas_scene_seat_get_static_delegate = new efl_canvas_scene_seat_get_delegate(seat_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_seat_get_static_delegate) });
            }

            if (efl_canvas_scene_seat_default_get_static_delegate == null)
            {
                efl_canvas_scene_seat_default_get_static_delegate = new efl_canvas_scene_seat_default_get_delegate(seat_default_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeatDefault") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_seat_default_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_seat_default_get_static_delegate) });
            }

            if (efl_canvas_scene_pointer_position_get_static_delegate == null)
            {
                efl_canvas_scene_pointer_position_get_static_delegate = new efl_canvas_scene_pointer_position_get_delegate(pointer_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_pointer_position_get_static_delegate) });
            }

            if (efl_canvas_scene_group_objects_calculate_static_delegate == null)
            {
                efl_canvas_scene_group_objects_calculate_static_delegate = new efl_canvas_scene_group_objects_calculate_delegate(group_objects_calculate);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalculateGroupObjects") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_group_objects_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_group_objects_calculate_static_delegate) });
            }

            if (efl_canvas_scene_objects_at_xy_get_static_delegate == null)
            {
                efl_canvas_scene_objects_at_xy_get_static_delegate = new efl_canvas_scene_objects_at_xy_get_delegate(objects_at_xy_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetObjectsAtXy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_objects_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_at_xy_get_static_delegate) });
            }

            if (efl_canvas_scene_object_top_at_xy_get_static_delegate == null)
            {
                efl_canvas_scene_object_top_at_xy_get_static_delegate = new efl_canvas_scene_object_top_at_xy_get_delegate(object_top_at_xy_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetObjectTopAtXy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_object_top_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_at_xy_get_static_delegate) });
            }

            if (efl_canvas_scene_objects_in_rectangle_get_static_delegate == null)
            {
                efl_canvas_scene_objects_in_rectangle_get_static_delegate = new efl_canvas_scene_objects_in_rectangle_get_delegate(objects_in_rectangle_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetObjectsInRectangle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_objects_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_in_rectangle_get_static_delegate) });
            }

            if (efl_canvas_scene_object_top_in_rectangle_get_static_delegate == null)
            {
                efl_canvas_scene_object_top_in_rectangle_get_static_delegate = new efl_canvas_scene_object_top_in_rectangle_get_delegate(object_top_in_rectangle_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetObjectTopInRectangle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_object_top_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_in_rectangle_get_static_delegate) });
            }

            if (efl_canvas_scene_seats_static_delegate == null)
            {
                efl_canvas_scene_seats_static_delegate = new efl_canvas_scene_seats_delegate(seats);
            }

            if (methods.FirstOrDefault(m => m.Name == "Seats") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_seats"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_seats_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.ISceneConcrete.efl_canvas_scene_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_scene_image_max_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Eina.Size2D.NativeStruct max);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_scene_image_max_size_get_api_delegate(System.IntPtr obj,  out Eina.Size2D.NativeStruct max);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_image_max_size_get_api_delegate> efl_canvas_scene_image_max_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_image_max_size_get_api_delegate>(Module, "efl_canvas_scene_image_max_size_get");

        private static bool image_max_size_get(System.IntPtr obj, System.IntPtr pd, out Eina.Size2D.NativeStruct max)
        {
            Eina.Log.Debug("function efl_canvas_scene_image_max_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _out_max = default(Eina.Size2D);
                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetImageMaxSize(out _out_max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        max = _out_max;
                return _ret_var;

            }
            else
            {
                return efl_canvas_scene_image_max_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out max);
            }
        }

        private static efl_canvas_scene_image_max_size_get_delegate efl_canvas_scene_image_max_size_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_scene_group_objects_calculating_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_scene_group_objects_calculating_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_group_objects_calculating_get_api_delegate> efl_canvas_scene_group_objects_calculating_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_group_objects_calculating_get_api_delegate>(Module, "efl_canvas_scene_group_objects_calculating_get");

        private static bool group_objects_calculating_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_scene_group_objects_calculating_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetGroupObjectsCalculating();
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
                return efl_canvas_scene_group_objects_calculating_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_scene_group_objects_calculating_get_delegate efl_canvas_scene_group_objects_calculating_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Input.Device efl_canvas_scene_device_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Input.Device efl_canvas_scene_device_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_device_get_api_delegate> efl_canvas_scene_device_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_device_get_api_delegate>(Module, "efl_canvas_scene_device_get");

        private static Efl.Input.Device device_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_canvas_scene_device_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Input.Device _ret_var = default(Efl.Input.Device);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetDevice(name);
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
                return efl_canvas_scene_device_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_canvas_scene_device_get_delegate efl_canvas_scene_device_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Input.Device efl_canvas_scene_seat_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Input.Device efl_canvas_scene_seat_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_seat_get_api_delegate> efl_canvas_scene_seat_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_seat_get_api_delegate>(Module, "efl_canvas_scene_seat_get");

        private static Efl.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_canvas_scene_seat_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Input.Device _ret_var = default(Efl.Input.Device);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetSeat(id);
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
                return efl_canvas_scene_seat_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_canvas_scene_seat_get_delegate efl_canvas_scene_seat_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Input.Device efl_canvas_scene_seat_default_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Input.Device efl_canvas_scene_seat_default_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_seat_default_get_api_delegate> efl_canvas_scene_seat_default_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_seat_default_get_api_delegate>(Module, "efl_canvas_scene_seat_default_get");

        private static Efl.Input.Device seat_default_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_scene_seat_default_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Input.Device _ret_var = default(Efl.Input.Device);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetSeatDefault();
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
                return efl_canvas_scene_seat_default_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_scene_seat_default_get_delegate efl_canvas_scene_seat_default_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_scene_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat,  out Eina.Position2D.NativeStruct pos);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_scene_pointer_position_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat,  out Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_pointer_position_get_api_delegate> efl_canvas_scene_pointer_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_pointer_position_get_api_delegate>(Module, "efl_canvas_scene_pointer_position_get");

        private static bool pointer_position_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat, out Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_canvas_scene_pointer_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                Eina.Position2D _out_pos = default(Eina.Position2D);
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetPointerPosition(seat, out _out_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                pos = _out_pos;
                        return _ret_var;

            }
            else
            {
                return efl_canvas_scene_pointer_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat, out pos);
            }
        }

        private static efl_canvas_scene_pointer_position_get_delegate efl_canvas_scene_pointer_position_get_static_delegate;

        
        private delegate void efl_canvas_scene_group_objects_calculate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_canvas_scene_group_objects_calculate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_group_objects_calculate_api_delegate> efl_canvas_scene_group_objects_calculate_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_group_objects_calculate_api_delegate>(Module, "efl_canvas_scene_group_objects_calculate");

        private static void group_objects_calculate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_scene_group_objects_calculate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IScene)ws.Target).CalculateGroupObjects();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_canvas_scene_group_objects_calculate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_scene_group_objects_calculate_delegate efl_canvas_scene_group_objects_calculate_static_delegate;

        
        private delegate System.IntPtr efl_canvas_scene_objects_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        
        public delegate System.IntPtr efl_canvas_scene_objects_at_xy_get_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_objects_at_xy_get_api_delegate> efl_canvas_scene_objects_at_xy_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_objects_at_xy_get_api_delegate>(Module, "efl_canvas_scene_objects_at_xy_get");

        private static System.IntPtr objects_at_xy_get(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos, bool include_pass_events_objects, bool include_hidden_objects)
        {
            Eina.Log.Debug("function efl_canvas_scene_objects_at_xy_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                                                                            Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectsAtXy(_in_pos, include_pass_events_objects, include_hidden_objects);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_scene_objects_at_xy_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_objects_at_xy_get_delegate efl_canvas_scene_objects_at_xy_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_canvas_scene_object_top_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_canvas_scene_object_top_at_xy_get_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_object_top_at_xy_get_api_delegate> efl_canvas_scene_object_top_at_xy_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_object_top_at_xy_get_api_delegate>(Module, "efl_canvas_scene_object_top_at_xy_get");

        private static Efl.Gfx.IEntity object_top_at_xy_get(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos, bool include_pass_events_objects, bool include_hidden_objects)
        {
            Eina.Log.Debug("function efl_canvas_scene_object_top_at_xy_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                                                                            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectTopAtXy(_in_pos, include_pass_events_objects, include_hidden_objects);
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
                return efl_canvas_scene_object_top_at_xy_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_object_top_at_xy_get_delegate efl_canvas_scene_object_top_at_xy_get_static_delegate;

        
        private delegate System.IntPtr efl_canvas_scene_objects_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        
        public delegate System.IntPtr efl_canvas_scene_objects_in_rectangle_get_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_objects_in_rectangle_get_api_delegate> efl_canvas_scene_objects_in_rectangle_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_objects_in_rectangle_get_api_delegate>(Module, "efl_canvas_scene_objects_in_rectangle_get");

        private static System.IntPtr objects_in_rectangle_get(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect, bool include_pass_events_objects, bool include_hidden_objects)
        {
            Eina.Log.Debug("function efl_canvas_scene_objects_in_rectangle_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                                                                            Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectsInRectangle(_in_rect, include_pass_events_objects, include_hidden_objects);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_scene_objects_in_rectangle_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_objects_in_rectangle_get_delegate efl_canvas_scene_objects_in_rectangle_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_canvas_scene_object_top_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_canvas_scene_object_top_in_rectangle_get_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_object_top_in_rectangle_get_api_delegate> efl_canvas_scene_object_top_in_rectangle_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_object_top_in_rectangle_get_api_delegate>(Module, "efl_canvas_scene_object_top_in_rectangle_get");

        private static Efl.Gfx.IEntity object_top_in_rectangle_get(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect, bool include_pass_events_objects, bool include_hidden_objects)
        {
            Eina.Log.Debug("function efl_canvas_scene_object_top_in_rectangle_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                                                                            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectTopInRectangle(_in_rect, include_pass_events_objects, include_hidden_objects);
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
                return efl_canvas_scene_object_top_in_rectangle_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_object_top_in_rectangle_get_delegate efl_canvas_scene_object_top_in_rectangle_get_static_delegate;

        
        private delegate System.IntPtr efl_canvas_scene_seats_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_scene_seats_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_scene_seats_api_delegate> efl_canvas_scene_seats_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_scene_seats_api_delegate>(Module, "efl_canvas_scene_seats");

        private static System.IntPtr seats(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_scene_seats was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Input.Device> _ret_var = default(Eina.Iterator<Efl.Input.Device>);
                try
                {
                    _ret_var = ((IScene)ws.Target).Seats();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_scene_seats_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_scene_seats_delegate efl_canvas_scene_seats_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasISceneConcrete_ExtensionMethods {
    
    
    
    
    
    
}
#pragma warning restore CS1591
#endif
