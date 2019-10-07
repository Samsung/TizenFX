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

/// <summary>Common class for part proxy objects for <see cref="Efl.Canvas.Layout"/>.
/// As an <see cref="Efl.IPart"/> implementation class, all objects of this class are meant to be used for one and only one function call. In pseudo-code, the use of object of this type looks like the following: rect = layout.part(&quot;somepart&quot;).geometry_get();</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.LayoutPart.NativeMethods]
[Efl.Eo.BindingEntity]
public class LayoutPart : Efl.Object, Efl.Gfx.IEntity, Efl.Ui.IDrag
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LayoutPart))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Edje)] internal static extern System.IntPtr
        efl_canvas_layout_part_class_get();

    /// <summary>Initializes a new instance of the <see cref="LayoutPart"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LayoutPart(Efl.Object parent= null
            ) : base(efl_canvas_layout_part_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected LayoutPart(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LayoutPart"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LayoutPart(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LayoutPart"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LayoutPart(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Gfx.EntityVisibilityChangedEventArgs"/></value>
    public event EventHandler<Efl.Gfx.EntityVisibilityChangedEventArgs> VisibilityChangedEvent
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
                        Efl.Gfx.EntityVisibilityChangedEventArgs args = new Efl.Gfx.EntityVisibilityChangedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Edje, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Edje, key, value);
            }
        }
    }

    /// <summary>Method to raise event VisibilityChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnVisibilityChangedEvent(Efl.Gfx.EntityVisibilityChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Edje, key);
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

    /// <summary>Object was moved, its position during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Gfx.EntityPositionChangedEventArgs"/></value>
    public event EventHandler<Efl.Gfx.EntityPositionChangedEventArgs> PositionChangedEvent
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
                        Efl.Gfx.EntityPositionChangedEventArgs args = new Efl.Gfx.EntityPositionChangedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Edje, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Edje, key, value);
            }
        }
    }

    /// <summary>Method to raise event PositionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPositionChangedEvent(Efl.Gfx.EntityPositionChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Edje, key);
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

    /// <summary>Object was resized, its size during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Gfx.EntitySizeChangedEventArgs"/></value>
    public event EventHandler<Efl.Gfx.EntitySizeChangedEventArgs> SizeChangedEvent
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
                        Efl.Gfx.EntitySizeChangedEventArgs args = new Efl.Gfx.EntitySizeChangedEventArgs();
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
                AddNativeEventHandler(efl.Libs.Edje, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Edje, key, value);
            }
        }
    }

    /// <summary>Method to raise event SizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSizeChangedEvent(Efl.Gfx.EntitySizeChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Edje, key);
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

    /// <summary>The name and value of the current state of this part (read-only).
    /// This is the state name as it appears in EDC description blocks. A state has both a name and a value (double). The default state is &quot;default&quot; 0.0, but this function will return &quot;&quot; if the part is invalid.</summary>
    /// <param name="state">The name of the state.<br/>The default value is <c>&quot;&quot;</c>.</param>
    /// <param name="val">The value of the state.<br/>The default value is <c>0.000000</c>.</param>
    public virtual void GetState(out System.String state, out double val) {
        Efl.Canvas.LayoutPart.NativeMethods.efl_canvas_layout_part_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out state, out val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Returns the type of the part.</summary>
    /// <returns>One of the types or <c>none</c> if not an existing part.</returns>
    public virtual Efl.Canvas.LayoutPartType GetPartType() {
        var _ret_var = Efl.Canvas.LayoutPart.NativeMethods.efl_canvas_layout_part_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Retrieves the position of the given canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public virtual Eina.Position2D GetPosition() {
        var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    public virtual void SetPosition(Eina.Position2D pos) {
        Eina.Position2D.NativeStruct _in_pos = pos;
Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D size in pixel units.</returns>
    public virtual Eina.Size2D GetSize() {
        var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="size">A 2D size in pixel units.</param>
    public virtual void SetSize(Eina.Size2D size) {
        Eina.Size2D.NativeStruct _in_size = size;
Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public virtual Eina.Rect GetGeometry() {
        var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    public virtual void SetGeometry(Eina.Rect rect) {
        Eina.Rect.NativeStruct _in_rect = rect;
Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public virtual bool GetVisible() {
        var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Shows or hides this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    public virtual void SetVisible(bool v) {
        Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an object&apos;s scaling factor.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The scaling factor.</returns>
    public virtual double GetScale() {
        var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the scaling factor of an object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
    public virtual void SetScale(double scale) {
        Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets the draggable object location.</summary>
    /// <param name="dx">The x relative position, from 0 to 1.</param>
    /// <param name="dy">The y relative position, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool GetDragValue(out double dx, out double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out dx, out dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the draggable object location.
    /// This places the draggable object at the given location.</summary>
    /// <param name="dx">The x relative position, from 0 to 1.</param>
    /// <param name="dy">The y relative position, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool SetDragValue(double dx, double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets the size of the dradgable object.</summary>
    /// <param name="dw">The drag relative width, from 0 to 1.</param>
    /// <param name="dh">The drag relative height, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool GetDragSize(out double dw, out double dh) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out dw, out dh);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the size of the draggable object.</summary>
    /// <param name="dw">The drag relative width, from 0 to 1.</param>
    /// <param name="dh">The drag relative height, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool SetDragSize(double dw, double dh) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dw, dh);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets the draggable direction.</summary>
    /// <returns>The direction(s) premitted for drag.</returns>
    public virtual Efl.Ui.DragDir GetDragDir() {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_dir_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets the x and y step increments for the draggable object.</summary>
    /// <param name="dx">The x step relative amount, from 0 to 1.</param>
    /// <param name="dy">The y step relative amount, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool GetDragStep(out double dx, out double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out dx, out dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the x,y step increments for a draggable object.</summary>
    /// <param name="dx">The x step relative amount, from 0 to 1.</param>
    /// <param name="dy">The y step relative amount, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool SetDragStep(double dx, double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Gets the x,y page step increments for the draggable object.</summary>
    /// <param name="dx">The x page step increment</param>
    /// <param name="dy">The y page step increment</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool GetDragPage(out double dx, out double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_page_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out dx, out dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the x,y page step increment values.</summary>
    /// <param name="dx">The x page step increment</param>
    /// <param name="dy">The y page step increment</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool SetDragPage(double dx, double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_page_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
    /// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.IDrag.GetDragStep"/>.
    /// 
    /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.</summary>
    /// <param name="dx">The number of steps horizontally.</param>
    /// <param name="dy">The number of steps vertically.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool MoveDragStep(double dx, double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_step_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
    /// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.IDrag.GetDragPage"/>.
    /// 
    /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
    /// 
    /// Warning: Paging is bugged!</summary>
    /// <param name="dx">The number of pages horizontally.</param>
    /// <param name="dy">The number of pages vertically.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool MoveDragPage(double dx, double dy) {
        var _ret_var = Efl.Ui.DragConcrete.NativeMethods.efl_ui_drag_page_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The name and value of the current state of this part (read-only).
    /// This is the state name as it appears in EDC description blocks. A state has both a name and a value (double). The default state is &quot;default&quot; 0.0, but this function will return &quot;&quot; if the part is invalid.</summary>
    public (System.String, double) State {
        get {
            System.String _out_state = default(System.String);
            double _out_val = default(double);
            GetState(out _out_state,out _out_val);
            return (_out_state,_out_val);
        }
    }

    /// <summary>Type of this part in the layout.</summary>
    /// <value>One of the types or <c>none</c> if not an existing part.</value>
    public Efl.Canvas.LayoutPartType PartType {
        get { return GetPartType(); }
    }

    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D coordinate in pixel units.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }

    /// <summary>The 2D size of a canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixel units.</value>
    public Eina.Size2D Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    public Eina.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry(value); }
    }

    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible(value); }
    }

    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The scaling factor.</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale(value); }
    }

    /// <summary>The draggable object relative location.
    /// Some parts in Edje can be dragged along the X/Y axes, if the part contains a &quot;draggable&quot; section (in EDC). For instance, scroll bars can be draggable objects.
    /// 
    /// <c>dx</c> and <c>dy</c> are real numbers that range from 0 to 1, representing the relative position to the draggable area on that axis.
    /// 
    /// This value means, for the vertical axis, that 0.0 will be at the top if the first parameter of <c>y</c> in the draggable part theme is 1 and at the bottom if it is -1.
    /// 
    /// For the horizontal axis, 0.0 means left if the first parameter of <c>x</c> in the draggable part theme is 1, and right if it is -1.</summary>
    /// <value>The x relative position, from 0 to 1.</value>
    public (double, double) DragValue {
        get {
            double _out_dx = default(double);
            double _out_dy = default(double);
            GetDragValue(out _out_dx,out _out_dy);
            return (_out_dx,_out_dy);
        }
        set { SetDragValue( value.Item1,  value.Item2); }
    }

    /// <summary>The draggable object relative size.
    /// Values for <c>dw</c> and <c>dh</c> are real numbers that range from 0 to 1, representing the relative size of the draggable area on that axis.
    /// 
    /// For instance a scroll bar handle size may depend on the size of the scroller&apos;s content.</summary>
    /// <value>The drag relative width, from 0 to 1.</value>
    public (double, double) DragSize {
        get {
            double _out_dw = default(double);
            double _out_dh = default(double);
            GetDragSize(out _out_dw,out _out_dh);
            return (_out_dw,_out_dh);
        }
        set { SetDragSize( value.Item1,  value.Item2); }
    }

    /// <summary>Determines the draggable directions (read-only).
    /// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.</summary>
    /// <value>The direction(s) premitted for drag.</value>
    public Efl.Ui.DragDir DragDir {
        get { return GetDragDir(); }
    }

    /// <summary>The drag step increment.
    /// Values for <c>dx</c> and <c>dy</c> are real numbers that range from 0 to 1, representing the relative size of the draggable area on that axis by which the part will be moved.
    /// 
    /// This differs from <see cref="Efl.Ui.IDrag.GetDragPage"/> in that this is meant to represent a unit increment, like a single line for example.
    /// 
    /// See also <see cref="Efl.Ui.IDrag.GetDragPage"/>.</summary>
    /// <value>The x step relative amount, from 0 to 1.</value>
    public (double, double) DragStep {
        get {
            double _out_dx = default(double);
            double _out_dy = default(double);
            GetDragStep(out _out_dx,out _out_dy);
            return (_out_dx,_out_dy);
        }
        set { SetDragStep( value.Item1,  value.Item2); }
    }

    /// <summary>The page step increments.
    /// Values for <c>dx</c> and <c>dy</c> are real numbers that range from 0 to 1, representing the relative size of the draggable area on that axis by which the part will be moved.
    /// 
    /// This differs from <see cref="Efl.Ui.IDrag.GetDragStep"/> in that this is meant to be a larger step size, basically an entire page as opposed to a single or couple of lines.
    /// 
    /// See also <see cref="Efl.Ui.IDrag.GetDragStep"/>.</summary>
    /// <value>The x page step increment</value>
    public (double, double) DragPage {
        get {
            double _out_dx = default(double);
            double _out_dy = default(double);
            GetDragPage(out _out_dx,out _out_dy);
            return (_out_dx,_out_dy);
        }
        set { SetDragPage( value.Item1,  value.Item2); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.LayoutPart.efl_canvas_layout_part_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Edje);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_layout_part_state_get_static_delegate == null)
            {
                efl_canvas_layout_part_state_get_static_delegate = new efl_canvas_layout_part_state_get_delegate(state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_layout_part_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_state_get_static_delegate) });
            }

            if (efl_canvas_layout_part_type_get_static_delegate == null)
            {
                efl_canvas_layout_part_type_get_static_delegate = new efl_canvas_layout_part_type_get_delegate(part_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPartType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_layout_part_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_layout_part_type_get_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.LayoutPart.efl_canvas_layout_part_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_canvas_layout_part_state_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String state,  out double val);

        
        public delegate void efl_canvas_layout_part_state_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String state,  out double val);

        public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_state_get_api_delegate> efl_canvas_layout_part_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_state_get_api_delegate>(Module, "efl_canvas_layout_part_state_get");

        private static void state_get(System.IntPtr obj, System.IntPtr pd, out System.String state, out double val)
        {
            Eina.Log.Debug("function efl_canvas_layout_part_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _out_state = default(System.String);
val = default(double);
                try
                {
                    ((LayoutPart)ws.Target).GetState(out _out_state, out val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        state = _out_state;
        
            }
            else
            {
                efl_canvas_layout_part_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out state, out val);
            }
        }

        private static efl_canvas_layout_part_state_get_delegate efl_canvas_layout_part_state_get_static_delegate;

        
        private delegate Efl.Canvas.LayoutPartType efl_canvas_layout_part_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Canvas.LayoutPartType efl_canvas_layout_part_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_layout_part_type_get_api_delegate> efl_canvas_layout_part_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_layout_part_type_get_api_delegate>(Module, "efl_canvas_layout_part_type_get");

        private static Efl.Canvas.LayoutPartType part_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_layout_part_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Canvas.LayoutPartType _ret_var = default(Efl.Canvas.LayoutPartType);
                try
                {
                    _ret_var = ((LayoutPart)ws.Target).GetPartType();
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
                return efl_canvas_layout_part_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_layout_part_type_get_delegate efl_canvas_layout_part_type_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasLayoutPart_ExtensionMethods {
    public static Efl.BindableProperty<Eina.Position2D> Position<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.LayoutPart, T>magic = null) where T : Efl.Canvas.LayoutPart {
        return new Efl.BindableProperty<Eina.Position2D>("position", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> Size<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.LayoutPart, T>magic = null) where T : Efl.Canvas.LayoutPart {
        return new Efl.BindableProperty<Eina.Size2D>("size", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Geometry<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.LayoutPart, T>magic = null) where T : Efl.Canvas.LayoutPart {
        return new Efl.BindableProperty<Eina.Rect>("geometry", fac);
    }

    public static Efl.BindableProperty<bool> Visible<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.LayoutPart, T>magic = null) where T : Efl.Canvas.LayoutPart {
        return new Efl.BindableProperty<bool>("visible", fac);
    }

    public static Efl.BindableProperty<double> Scale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.LayoutPart, T>magic = null) where T : Efl.Canvas.LayoutPart {
        return new Efl.BindableProperty<double>("scale", fac);
    }

}
#pragma warning restore CS1591
#endif
