#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>A container that arranges children widgets in a vertical or horizontal fashion.
/// The Box widget is the most basic (and the most used) of the container widgets. Other widgets are added to the Box through the <see cref="Efl.IPackLinear"/> interface, and the layout direction (either vertical or horizontal) is controlled through the <see cref="Efl.Ui.ILayoutOrientable.Orientation"/> property.
/// 
/// The Box widget itself is invisible, as are most container widgets: Their purpose is to handle the position and size of all their children so you don&apos;t have to.
/// 
/// All widgets inside a vertical Box container will have the same width as the container, and their heights will be automatically chosen so that they cover the whole surface of the container from top to bottom (Imagine a stack of pizza boxes neatly fitting inside your oven). The <see cref="Efl.Ui.Box.Homogeneous"/> property then controls whether all widgets have the same height (homogeneous) or not.
/// 
/// A horizontal Box container example would be the button toolbar at the top of most word processing programs.
/// 
/// Precise layout can be further customized through the <see cref="Efl.Gfx.IArrangement"/> interface on the Box itself, or through the <see cref="Efl.Gfx.IHint"/> interface on each of the children widgets.</summary>
[Efl.Ui.Box.NativeMethods]
[Efl.Eo.BindingEntity]
public class Box : Efl.Ui.Widget, Efl.IContainer, Efl.IPack, Efl.IPackLayout, Efl.IPackLinear, Efl.Gfx.IArrangement, Efl.Ui.ILayoutOrientable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Box))
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
        efl_ui_box_class_get();
    /// <summary>Initializes a new instance of the <see cref="Box"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Box(Efl.Object parent
            , System.String style = null) : base(efl_ui_box_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Box(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Box"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Box(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Box"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Box(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sent after a new sub-object was added.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentAddedEventArgs> ContentAddedEvent
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
                        Efl.ContainerContentAddedEventArgs args = new Efl.ContainerContentAddedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentAddedEvent(Efl.ContainerContentAddedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after a sub-object was removed, before unref.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentRemovedEventArgs> ContentRemovedEvent
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
                        Efl.ContainerContentRemovedEventArgs args = new Efl.ContainerContentRemovedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentRemovedEvent(Efl.ContainerContentRemovedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvent
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

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LayoutUpdatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLayoutUpdatedEvent(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
    /// <returns><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</returns>
    public virtual bool GetHomogeneous() {
         var _ret_var = Efl.Ui.Box.NativeMethods.efl_ui_box_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
    /// <param name="homogeneous"><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</param>
    public virtual void SetHomogeneous(bool homogeneous) {
                                 Efl.Ui.Box.NativeMethods.efl_ui_box_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),homogeneous);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator on object&apos;s content.</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns the number of contained sub-objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of sub-objects.</returns>
    public virtual int ContentCount() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool ClearPack() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool UnpackAll() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public virtual bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Requests EFL to recalculate the layout of this object.
    /// Internal layout methods might be called asynchronously.</summary>
    public virtual void LayoutRequest() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overridden to implement custom layout behaviors.</summary>
    protected virtual void UpdateLayout() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Prepend an object at the beginning of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/> with a <c>0</c> index.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the beginning.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool PackBegin(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_begin_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Append object at the end of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/> with a <c>-1</c> index.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the end.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool PackEnd(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend an object before an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack before <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    public virtual bool PackBefore(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_before_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Append an object after an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack after <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    public virtual bool PackAfter(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_after_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
    /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than <c>-count</c>, it will trigger <see cref="Efl.IPackLinear.PackBegin"/> whereas <c>index</c> greater than <c>count-1</c> will trigger <see cref="Efl.IPackLinear.PackEnd"/>.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack.</param>
    /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is <c>-count</c> to <c>count-1</c>).</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool PackAt(Efl.Gfx.IEntity subobj, int index) {
                                                         var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sub-object at a given <c>index</c> in this container.
    /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than <c>-count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count-1</c> will return the last sub-object.</summary>
    /// <param name="index">Index of the existing sub-object to retrieve. Valid range is <c>-count</c> to <c>count-1</c>.</param>
    /// <returns>The sub-object contained at the given <c>index</c>.</returns>
    public virtual Efl.Gfx.IEntity GetPackContent(int index) {
                                 var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the index of a sub-object in this container.</summary>
    /// <param name="subobj">An existing sub-object in this container.</param>
    /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range <c>0</c> to <c>count-1</c>.</returns>
    public virtual int GetPackIndex(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
    /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
    /// <param name="index">Index of the sub-object to remove. Valid range is <c>-count</c> to <c>count-1</c>.</param>
    /// <returns>The sub-object if it could be removed.</returns>
    public virtual Efl.Gfx.IEntity PackUnpackAt(int index) {
                                 var _ret_var = Efl.PackLinearConcrete.NativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    public virtual Efl.Ui.LayoutOrientation GetOrientation() {
         var _ret_var = Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    public virtual void SetOrientation(Efl.Ui.LayoutOrientation dir) {
                                 Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>In homogeneous mode all children of a vertical Box have the same height, equal to the height of the tallest widget. Children of a horizontal Box have the same width, equal to the width of the widest widget. Otherwise, individual widget sizes are not modified.</summary>
    /// <value><c>true</c> if the Box is homogeneous, <c>false</c> otherwise.</value>
    public bool Homogeneous {
        get { return GetHomogeneous(); }
        set { SetHomogeneous(value); }
    }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</value>
    public (double, double) ContentAlign {
        get {
            double _out_align_horiz = default(double);
            double _out_align_vert = default(double);
            GetContentAlign(out _out_align_horiz,out _out_align_vert);
            return (_out_align_horiz,_out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Horizontal padding. The default value is 0.0.</value>
    public (double, double, bool) ContentPadding {
        get {
            double _out_pad_horiz = default(double);
            double _out_pad_vert = default(double);
            bool _out_scalable = default(bool);
            GetContentPadding(out _out_pad_horiz,out _out_pad_vert,out _out_scalable);
            return (_out_pad_horiz,_out_pad_vert,_out_scalable);
        }
        set { SetContentPadding( value.Item1,  value.Item2,  value.Item3); }
    }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <value>Direction of the widget.</value>
    public Efl.Ui.LayoutOrientation Orientation {
        get { return GetOrientation(); }
        set { SetOrientation(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Box.efl_ui_box_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_box_homogeneous_get_static_delegate == null)
            {
                efl_ui_box_homogeneous_get_static_delegate = new efl_ui_box_homogeneous_get_delegate(homogeneous_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_box_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_homogeneous_get_static_delegate) });
            }

            if (efl_ui_box_homogeneous_set_static_delegate == null)
            {
                efl_ui_box_homogeneous_set_static_delegate = new efl_ui_box_homogeneous_set_delegate(homogeneous_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_box_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_box_homogeneous_set_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
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
            return Efl.Ui.Box.efl_ui_box_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_box_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_box_homogeneous_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_box_homogeneous_get_api_delegate> efl_ui_box_homogeneous_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_homogeneous_get_api_delegate>(Module, "efl_ui_box_homogeneous_get");

        private static bool homogeneous_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_box_homogeneous_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Box)ws.Target).GetHomogeneous();
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
                return efl_ui_box_homogeneous_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_box_homogeneous_get_delegate efl_ui_box_homogeneous_get_static_delegate;

        
        private delegate void efl_ui_box_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

        
        public delegate void efl_ui_box_homogeneous_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

        public static Efl.Eo.FunctionWrapper<efl_ui_box_homogeneous_set_api_delegate> efl_ui_box_homogeneous_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_box_homogeneous_set_api_delegate>(Module, "efl_ui_box_homogeneous_set");

        private static void homogeneous_set(System.IntPtr obj, System.IntPtr pd, bool homogeneous)
        {
            Eina.Log.Debug("function efl_ui_box_homogeneous_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Box)ws.Target).SetHomogeneous(homogeneous);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_box_homogeneous_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), homogeneous);
            }
        }

        private static efl_ui_box_homogeneous_set_delegate efl_ui_box_homogeneous_set_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Box)ws.Target).UpdateLayout();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiBox_ExtensionMethods {
    public static Efl.BindableProperty<bool> Homogeneous<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Box, T>magic = null) where T : Efl.Ui.Box {
        return new Efl.BindableProperty<bool>("homogeneous", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Box, T>magic = null) where T : Efl.Ui.Box {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

}
#pragma warning restore CS1591
#endif
