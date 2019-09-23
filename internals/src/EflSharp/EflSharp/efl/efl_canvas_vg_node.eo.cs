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

namespace Vg {

/// <summary>Efl vector graphics abstract class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Node.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Node : Efl.Object, Efl.IDuplicate, Efl.Gfx.IColor, Efl.Gfx.IEntity, Efl.Gfx.IPath, Efl.Gfx.IStack
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Node))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_vg_node_class_get();
    /// <summary>Initializes a new instance of the <see cref="Node"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Node(Efl.Object parent= null
            ) : base(efl_canvas_vg_node_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Node(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Node"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Node(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class NodeRealized : Node
    {
        private NodeRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Node"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Node(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event VisibilityChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnVisibilityChangedEvent(Efl.Gfx.EntityVisibilityChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PositionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPositionChangedEvent(Efl.Gfx.EntityPositionChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event SizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSizeChangedEvent(Efl.Gfx.EntitySizeChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
    public event EventHandler StackingChangedEvent
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

                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event StackingChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStackingChangedEvent(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The transformation matrix to be used for this node object.
    /// Note: Pass <c>null</c> to cancel the applied transformation.</summary>
    /// <returns>Transformation matrix.</returns>
    public virtual Eina.Matrix3 GetTransformation() {
         var _ret_var = Efl.Canvas.Vg.Node.NativeMethods.efl_canvas_vg_node_transformation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Eina.Matrix3>(_ret_var);
        
        return __ret_tmp;
 }
    /// <summary>The transformation matrix to be used for this node object.
    /// Note: Pass <c>null</c> to cancel the applied transformation.</summary>
    /// <param name="m">Transformation matrix.</param>
    public virtual void SetTransformation(ref Eina.Matrix3 m) {
         Eina.Matrix3.NativeStruct _in_m = m;
                        Efl.Canvas.Vg.Node.NativeMethods.efl_canvas_vg_node_transformation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_m);
        Eina.Error.RaiseIfUnhandledException();
                m = _in_m;
         }
    /// <summary>The origin position of the node object.
    /// This origin position affects node transformation.</summary>
    /// <param name="x"><c>origin</c> x position.</param>
    /// <param name="y"><c>origin</c> y position.</param>
    public virtual void GetOrigin(out double x, out double y) {
                                                         Efl.Canvas.Vg.Node.NativeMethods.efl_canvas_vg_node_origin_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The origin position of the node object.
    /// This origin position affects node transformation.</summary>
    /// <param name="x"><c>origin</c> x position.</param>
    /// <param name="y"><c>origin</c> y position.</param>
    public virtual void SetOrigin(double x, double y) {
                                                         Efl.Canvas.Vg.Node.NativeMethods.efl_canvas_vg_node_origin_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set a composite target node to this node object.</summary>
    /// <param name="target">Composite target node</param>
    /// <param name="method">Composite Method.</param>
    public virtual void SetCompMethod(Efl.Canvas.Vg.Node target, Efl.Gfx.VgCompositeMethod method) {
                                                         Efl.Canvas.Vg.Node.NativeMethods.efl_canvas_vg_node_comp_method_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),target, method);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    public virtual Efl.IDuplicate Duplicate() {
         var _ret_var = Efl.DuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public virtual void GetColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public virtual void SetColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    public virtual System.String GetColorCode() {
         var _ret_var = Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    public virtual void SetColorCode(System.String colorcode) {
                                 Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),colorcode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the position of the given canvas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public virtual Eina.Position2D GetPosition() {
         var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    public virtual void SetPosition(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D size in pixel units.</returns>
    public virtual Eina.Size2D GetSize() {
         var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
    /// (Since EFL 1.22)</summary>
    /// <param name="size">A 2D size in pixel units.</param>
    public virtual void SetSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public virtual Eina.Rect GetGeometry() {
         var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    public virtual void SetGeometry(Eina.Rect rect) {
         Eina.Rect.NativeStruct _in_rect = rect;
                        Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given canvas object is visible.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public virtual bool GetVisible() {
         var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Shows or hides this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    public virtual void SetVisible(bool v) {
                                 Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an object&apos;s scaling factor.
    /// (Since EFL 1.22)</summary>
    /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
    public virtual double GetScale() {
         var _ret_var = Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the scaling factor of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
    public virtual void SetScale(double scale) {
                                 Efl.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    public virtual void GetPath(out Efl.Gfx.PathCommandType op, out double points) {
                         System.IntPtr _out_op = System.IntPtr.Zero;
        System.IntPtr _out_points = System.IntPtr.Zero;
                        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_op, out _out_points);
        Eina.Error.RaiseIfUnhandledException();
        op = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.PathCommandType>(_out_op);
        points = Eina.PrimitiveConversion.PointerToManaged<double>(_out_points);
                         }
    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <param name="op">Command list</param>
    /// <param name="points">Point list</param>
    public virtual void SetPath(Efl.Gfx.PathCommandType op, double points) {
         var _in_op = Eina.PrimitiveConversion.ManagedToPointerAlloc(op);
        var _in_points = Eina.PrimitiveConversion.ManagedToPointerAlloc(points);
                                        Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_op, _in_points);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Path length property</summary>
    /// <param name="commands">Commands</param>
    /// <param name="points">Points</param>
    public virtual void GetLength(out uint commands, out uint points) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out commands, out points);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Current point coordinates</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    public virtual void GetCurrent(out double x, out double y) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_current_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Current control point coordinates</summary>
    /// <param name="x">X co-ordinate of control point.</param>
    /// <param name="y">Y co-ordinate of control point.</param>
    public virtual void GetCurrentCtrl(out double x, out double y) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_current_ctrl_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Copy the path data from the object specified.</summary>
    /// <param name="dup_from">Shape object from where data will be copied.</param>
    public virtual void CopyFrom(Efl.Object dup_from) {
                                 Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_copy_from_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dup_from);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Compute and return the bounding box of the currently set path</summary>
    /// <param name="r">Contain the bounding box of the currently set path</param>
    public virtual void GetBounds(out Eina.Rect r) {
                 var _out_r = new Eina.Rect.NativeStruct();
                Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_bounds_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_r);
        Eina.Error.RaiseIfUnhandledException();
        r = _out_r;
                 }
    /// <summary>Reset the path data of the path object.</summary>
    public virtual void Reset() {
         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Moves the current point to the given point,  implicitly starting a new subpath and closing the previous one.
    /// See also <see cref="Efl.Gfx.IPath.CloseAppend"/>.</summary>
    /// <param name="x">X co-ordinate of the current point.</param>
    /// <param name="y">Y co-ordinate of the current point.</param>
    public virtual void AppendMoveTo(double x, double y) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_move_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a straight line from the current position to the given end point. After the line is drawn, the current position is updated to be at the end point of the line.
    /// If no current position present, it draws a line to itself, basically a point.
    /// 
    /// See also <see cref="Efl.Gfx.IPath.AppendMoveTo"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendLineTo(double x, double y) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_line_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a quadratic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x, ctrl_y). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of control point.</param>
    public virtual void AppendQuadraticTo(double x, double y, double ctrl_x, double ctrl_y) {
                                                                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_quadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Same as <see cref="Efl.Gfx.IPath.AppendQuadraticTo"/> api only difference is that it uses the current control point to draw the bezier.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendSquadraticTo(double x, double y) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_squadratic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a cubic Bezier curve between the current position and the given end point (x,y) using the control points specified by (ctrl_x0, ctrl_y0), and (ctrl_x1, ctrl_y1). After the path is drawn, the current position is updated to be at the end point of the path.</summary>
    /// <param name="ctrl_x0">X co-ordinate of 1st control point.</param>
    /// <param name="ctrl_y0">Y co-ordinate of 1st control point.</param>
    /// <param name="ctrl_x1">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y1">Y co-ordinate of 2nd control point.</param>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    public virtual void AppendCubicTo(double ctrl_x0, double ctrl_y0, double ctrl_x1, double ctrl_y1, double x, double y) {
                                                                                                                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_cubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ctrl_x0, ctrl_y0, ctrl_x1, ctrl_y1, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Same as <see cref="Efl.Gfx.IPath.AppendCubicTo"/> api only difference is that it uses the current control point to draw the bezier.</summary>
    /// <param name="x">X co-ordinate of end point of the line.</param>
    /// <param name="y">Y co-ordinate of end point of the line.</param>
    /// <param name="ctrl_x">X co-ordinate of 2nd control point.</param>
    /// <param name="ctrl_y">Y co-ordinate of 2nd control point.</param>
    public virtual void AppendScubicTo(double x, double y, double ctrl_x, double ctrl_y) {
                                                                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_scubic_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, ctrl_x, ctrl_y);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Append an arc that connects from the current point int the point list to the given point (x,y). The arc is defined by the given radius in  x-direction (rx) and radius in y direction (ry).
    /// Use this api if you know the end point&apos;s of the arc otherwise use more convenient function <see cref="Efl.Gfx.IPath.AppendArc"/>.</summary>
    /// <param name="x">X co-ordinate of end point of the arc.</param>
    /// <param name="y">Y co-ordinate of end point of the arc.</param>
    /// <param name="rx">Radius of arc in x direction.</param>
    /// <param name="ry">Radius of arc in y direction.</param>
    /// <param name="angle">X-axis rotation , normally 0.</param>
    /// <param name="large_arc">Defines whether to draw the larger arc or smaller arc joining two point.</param>
    /// <param name="sweep">Defines whether the arc will be drawn counter-clockwise or clockwise from current point to the end point taking into account the large_arc property.</param>
    public virtual void AppendArcTo(double x, double y, double rx, double ry, double angle, bool large_arc, bool sweep) {
                                                                                                                                                                                 Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_arc_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, rx, ry, angle, large_arc, sweep);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Append an arc that enclosed in the given rectangle (x, y, w, h). The angle is defined in counter clock wise , use -ve angle for clockwise arc.</summary>
    /// <param name="x">X co-ordinate of the rect.</param>
    /// <param name="y">Y co-ordinate of the rect.</param>
    /// <param name="w">Width of the rect.</param>
    /// <param name="h">Height of the rect.</param>
    /// <param name="start_angle">Angle at which the arc will start</param>
    /// <param name="sweep_length">@ Length of the arc.</param>
    public virtual void AppendArc(double x, double y, double w, double h, double start_angle, double sweep_length) {
                                                                                                                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_arc_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, start_angle, sweep_length);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Closes the current subpath by drawing a line to the beginning of the subpath, automatically starting a new path. The current point of the new path is (0, 0).
    /// If the subpath does not contain any points, this function does nothing.</summary>
    public virtual void CloseAppend() {
         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_close_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Append a circle with given center and radius.</summary>
    /// <param name="x">X co-ordinate of the center of the circle.</param>
    /// <param name="y">Y co-ordinate of the center of the circle.</param>
    /// <param name="radius">Radius of the circle.</param>
    public virtual void AppendCircle(double x, double y, double radius) {
                                                                                 Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_circle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, radius);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Append the given rectangle with rounded corner to the path.
    /// The xr and yr arguments specify the radii of the ellipses defining the corners of the rounded rectangle.
    /// 
    /// xr and yr are specified in terms of width and height respectively.
    /// 
    /// If xr and yr are 0, then it will draw a rectangle without rounded corner.</summary>
    /// <param name="x">X co-ordinate of the rectangle.</param>
    /// <param name="y">Y co-ordinate of the rectangle.</param>
    /// <param name="w">Width of the rectangle.</param>
    /// <param name="h">Height of the rectangle.</param>
    /// <param name="rx">The x radius of the rounded corner and should be in range [ 0 to w/2 ]</param>
    /// <param name="ry">The y radius of the rounded corner and should be in range [ 0 to h/2 ]</param>
    public virtual void AppendRect(double x, double y, double w, double h, double rx, double ry) {
                                                                                                                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_rect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y, w, h, rx, ry);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Append SVG path data</summary>
    /// <param name="svg_path_data">SVG path data to append</param>
    public virtual void AppendSvgPath(System.String svg_path_data) {
                                 Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_append_svg_path_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),svg_path_data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Creates intermediary path part-way between two paths
    /// Sets the points of the <c>obj</c> as the linear interpolation of the points in the <c>from</c> and <c>to</c> paths.  The path&apos;s x,y position and control point coordinates are likewise interpolated.
    /// 
    /// The <c>from</c> and <c>to</c> paths must not already have equivalent points, and <c>to</c> must contain at least as many points as <c>from</c>, else the function returns <c>false</c> with no interpolation performed.  If <c>to</c> has more points than <c>from</c>, the excess points are ignored.</summary>
    /// <param name="from">Source path</param>
    /// <param name="to">Destination path</param>
    /// <param name="pos_map">Position map in range 0.0 to 1.0</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool Interpolate(Efl.Object from, Efl.Object to, double pos_map) {
                                                                                 var _ret_var = Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from, to, pos_map);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Equal commands in object</summary>
    /// <param name="with">Object</param>
    /// <returns>True on success, <c>false</c> otherwise</returns>
    public virtual bool EqualCommands(Efl.Object with) {
                                 var _ret_var = Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_equal_commands_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),with);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Reserve path commands buffer in advance. If you know the count of path commands coming, you can reserve commands buffer in advance to avoid buffer growing job.</summary>
    /// <param name="cmd_count">Commands count to reserve</param>
    /// <param name="pts_count">Pointers count to reserve</param>
    public virtual void Reserve(uint cmd_count, uint pts_count) {
                                                         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_reserve_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cmd_count, pts_count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Request to update the path object.
    /// One path object may get appending several path calls (such as append_cubic, append_rect, etc) to construct the final path data. Here commit means all path data is prepared and now object could update its own internal status based on the last path information.</summary>
    public virtual void Commit() {
         Efl.Gfx.PathConcrete.NativeMethods.efl_gfx_path_commit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
    public virtual short GetLayer() {
         var _ret_var = Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_layer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="l">The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</param>
    public virtual void SetLayer(short l) {
                                 Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_layer_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The Evas object stacked right below this object.
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.Layer"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public virtual Efl.Gfx.IStack GetBelow() {
         var _ret_var = Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_below_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the Evas object stacked right above this object.
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.Layer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public virtual Efl.Gfx.IStack GetAbove() {
         var _ret_var = Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_above_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    public virtual void StackBelow(Efl.Gfx.IStack below) {
                                 Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_below_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),below);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Raise <c>obj</c> to the top of its layer.
    /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.LowerToBottom"/>
    /// (Since EFL 1.22)</summary>
    public virtual void RaiseToTop() {
         Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_raise_to_top_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    public virtual void StackAbove(Efl.Gfx.IStack above) {
                                 Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_above_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),above);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Lower <c>obj</c> to the bottom of its layer.
    /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.RaiseToTop"/>
    /// (Since EFL 1.22)</summary>
    public virtual void LowerToBottom() {
         Efl.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The transformation matrix to be used for this node object.
    /// Note: Pass <c>null</c> to cancel the applied transformation.</summary>
    /// <value>Transformation matrix.</value>
    public Eina.Matrix3 Transformation {
        get { return GetTransformation(); }
        set { SetTransformation(ref value); }
    }
    /// <summary>The origin position of the node object.
    /// This origin position affects node transformation.</summary>
    /// <value><c>origin</c> x position.</value>
    public (double, double) Origin {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetOrigin(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetOrigin( value.Item1,  value.Item2); }
    }
    /// <summary>Set a composite target node to this node object.</summary>
    /// <value>Composite target node</value>
    public (Efl.Canvas.Vg.Node, Efl.Gfx.VgCompositeMethod) CompMethod {
        set { SetCompMethod( value.Item1,  value.Item2); }
    }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
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
    /// <summary>Set the list of commands and points to be used to create the content of path.</summary>
    /// <value>Command list</value>
    public (Efl.Gfx.PathCommandType, double) Path {
        get {
            Efl.Gfx.PathCommandType _out_op = default(Efl.Gfx.PathCommandType);
            double _out_points = default(double);
            GetPath(out _out_op,out _out_points);
            return (_out_op,_out_points);
        }
        set { SetPath( value.Item1,  value.Item2); }
    }
    /// <summary>Path length property</summary>
    public (uint, uint) Length {
        get {
            uint _out_commands = default(uint);
            uint _out_points = default(uint);
            GetLength(out _out_commands,out _out_points);
            return (_out_commands,_out_points);
        }
    }
    /// <summary>Current point coordinates</summary>
    public (double, double) Current {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetCurrent(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
    }
    /// <summary>Current control point coordinates</summary>
    public (double, double) CurrentCtrl {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetCurrentCtrl(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
    }
    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
    /// (Since EFL 1.22)</summary>
    /// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
    public short Layer {
        get { return GetLayer(); }
        set { SetLayer(value); }
    }
    /// <summary>The Evas object stacked right below this object.
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.Layer"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Below {
        get { return GetBelow(); }
    }
    /// <summary>Get the Evas object stacked right above this object.
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.Layer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Above {
        get { return GetAbove(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Node.efl_canvas_vg_node_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_vg_node_transformation_get_static_delegate == null)
            {
                efl_canvas_vg_node_transformation_get_static_delegate = new efl_canvas_vg_node_transformation_get_delegate(transformation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTransformation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_node_transformation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_node_transformation_get_static_delegate) });
            }

            if (efl_canvas_vg_node_transformation_set_static_delegate == null)
            {
                efl_canvas_vg_node_transformation_set_static_delegate = new efl_canvas_vg_node_transformation_set_delegate(transformation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTransformation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_node_transformation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_node_transformation_set_static_delegate) });
            }

            if (efl_canvas_vg_node_origin_get_static_delegate == null)
            {
                efl_canvas_vg_node_origin_get_static_delegate = new efl_canvas_vg_node_origin_get_delegate(origin_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOrigin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_node_origin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_node_origin_get_static_delegate) });
            }

            if (efl_canvas_vg_node_origin_set_static_delegate == null)
            {
                efl_canvas_vg_node_origin_set_static_delegate = new efl_canvas_vg_node_origin_set_delegate(origin_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOrigin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_node_origin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_node_origin_set_static_delegate) });
            }

            if (efl_canvas_vg_node_comp_method_set_static_delegate == null)
            {
                efl_canvas_vg_node_comp_method_set_static_delegate = new efl_canvas_vg_node_comp_method_set_delegate(comp_method_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCompMethod") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_node_comp_method_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_node_comp_method_set_static_delegate) });
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
            return Efl.Canvas.Vg.Node.efl_canvas_vg_node_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_canvas_vg_node_transformation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_vg_node_transformation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_node_transformation_get_api_delegate> efl_canvas_vg_node_transformation_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_node_transformation_get_api_delegate>(Module, "efl_canvas_vg_node_transformation_get");

        private static System.IntPtr transformation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_node_transformation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Matrix3 _ret_var = default(Eina.Matrix3);
                try
                {
                    _ret_var = ((Node)ws.Target).GetTransformation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_canvas_vg_node_transformation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_node_transformation_get_delegate efl_canvas_vg_node_transformation_get_static_delegate;

        
        private delegate void efl_canvas_vg_node_transformation_set_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.Matrix3.NativeStruct m);

        
        public delegate void efl_canvas_vg_node_transformation_set_api_delegate(System.IntPtr obj,  ref Eina.Matrix3.NativeStruct m);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_node_transformation_set_api_delegate> efl_canvas_vg_node_transformation_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_node_transformation_set_api_delegate>(Module, "efl_canvas_vg_node_transformation_set");

        private static void transformation_set(System.IntPtr obj, System.IntPtr pd, ref Eina.Matrix3.NativeStruct m)
        {
            Eina.Log.Debug("function efl_canvas_vg_node_transformation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Matrix3 _in_m = m;
                            
                try
                {
                    ((Node)ws.Target).SetTransformation(ref _in_m);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                m = _in_m;
        
            }
            else
            {
                efl_canvas_vg_node_transformation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref m);
            }
        }

        private static efl_canvas_vg_node_transformation_set_delegate efl_canvas_vg_node_transformation_set_static_delegate;

        
        private delegate void efl_canvas_vg_node_origin_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_canvas_vg_node_origin_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_node_origin_get_api_delegate> efl_canvas_vg_node_origin_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_node_origin_get_api_delegate>(Module, "efl_canvas_vg_node_origin_get");

        private static void origin_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_canvas_vg_node_origin_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((Node)ws.Target).GetOrigin(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_vg_node_origin_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_canvas_vg_node_origin_get_delegate efl_canvas_vg_node_origin_get_static_delegate;

        
        private delegate void efl_canvas_vg_node_origin_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_canvas_vg_node_origin_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_node_origin_set_api_delegate> efl_canvas_vg_node_origin_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_node_origin_set_api_delegate>(Module, "efl_canvas_vg_node_origin_set");

        private static void origin_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_canvas_vg_node_origin_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Node)ws.Target).SetOrigin(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_vg_node_origin_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_canvas_vg_node_origin_set_delegate efl_canvas_vg_node_origin_set_static_delegate;

        
        private delegate void efl_canvas_vg_node_comp_method_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node target,  Efl.Gfx.VgCompositeMethod method);

        
        public delegate void efl_canvas_vg_node_comp_method_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node target,  Efl.Gfx.VgCompositeMethod method);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_node_comp_method_set_api_delegate> efl_canvas_vg_node_comp_method_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_node_comp_method_set_api_delegate>(Module, "efl_canvas_vg_node_comp_method_set");

        private static void comp_method_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.Node target, Efl.Gfx.VgCompositeMethod method)
        {
            Eina.Log.Debug("function efl_canvas_vg_node_comp_method_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Node)ws.Target).SetCompMethod(target, method);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_canvas_vg_node_comp_method_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), target, method);
            }
        }

        private static efl_canvas_vg_node_comp_method_set_delegate efl_canvas_vg_node_comp_method_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgNode_ExtensionMethods {
    public static Efl.BindableProperty<Eina.Matrix3> Transformation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<Eina.Matrix3>("transformation", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> ColorCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<System.String>("color_code", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> Position<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<Eina.Position2D>("position", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> Size<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<Eina.Size2D>("size", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Geometry<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<Eina.Rect>("geometry", fac);
    }

    public static Efl.BindableProperty<bool> Visible<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<bool>("visible", fac);
    }

    public static Efl.BindableProperty<double> Scale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<double>("scale", fac);
    }

    
    
    
    
    public static Efl.BindableProperty<short> Layer<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Node, T>magic = null) where T : Efl.Canvas.Vg.Node {
        return new Efl.BindableProperty<short>("layer", fac);
    }

    
    
}
#pragma warning restore CS1591
#endif
