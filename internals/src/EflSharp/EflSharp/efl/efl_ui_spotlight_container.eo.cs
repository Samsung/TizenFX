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

namespace Spotlight {

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Spotlight.Container.TransitionStartEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ContainerTransitionStartEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A transition animation has started.</value>
    public Efl.Ui.Spotlight.TransitionEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Spotlight.Container.TransitionEndEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ContainerTransitionEndEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A transition animation has ended.</value>
    public Efl.Ui.Spotlight.TransitionEvent arg { get; set; }
}
/// <summary>The Spotlight widget is a container for other sub-widgets, where only one sub-widget is active at any given time.
/// Sub-widgets are added using the <see cref="Efl.IPackLinear"/> interface and the active one (the one in the &quot;spotlight&quot;) is selected using <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/>.
/// 
/// The way the different sub-widgets are rendered can be customized through the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> object. For example, only the active sub-widget might be shown, or it might be shown in a central position whereas the other sub-widgets are displayed on the sides, or grayed-out. All sub-widgets are displayed with the same size, selected with <see cref="Efl.Ui.Spotlight.Container.SpotlightSize"/>.
/// 
/// Additionally, the transition from one sub-widget to another can be animated. This animation is also controlled by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> object.
/// 
/// Also, an indicator widget can be used to show a visual cue of how many sub-widgets are there and which one is the active one.
/// 
/// This class can be used to create other widgets like Pagers, Tabbed pagers or Stacks, where each sub-widget represents a &quot;page&quot; full of other widgets. All these cases can be implemented with a different <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> and use the same <see cref="Efl.Ui.Spotlight.Container"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Spotlight.Container.NativeMethods]
[Efl.Eo.BindingEntity]
public class Container : Efl.Ui.LayoutBase, Efl.IPack, Efl.IPackLinear
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Container))
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
        efl_ui_spotlight_container_class_get();
    /// <summary>Initializes a new instance of the <see cref="Container"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Container(Efl.Object parent
            , System.String style = null) : base(efl_ui_spotlight_container_class_get(), parent)
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
    protected Container(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Container"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Container(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Container"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Container(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>A transition animation has started.</summary>
    /// <value><see cref="Efl.Ui.Spotlight.ContainerTransitionStartEvt_Args"/></value>
    public event EventHandler<Efl.Ui.Spotlight.ContainerTransitionStartEvt_Args> TransitionStartEvt
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
                        Efl.Ui.Spotlight.ContainerTransitionStartEvt_Args args = new Efl.Ui.Spotlight.ContainerTransitionStartEvt_Args();
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

                string key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event TransitionStartEvt.</summary>
    public void OnTransitionStartEvt(Efl.Ui.Spotlight.ContainerTransitionStartEvt_Args e)
    {
        var key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_START";
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
    /// <summary>A transition animation has ended.</summary>
    /// <value><see cref="Efl.Ui.Spotlight.ContainerTransitionEndEvt_Args"/></value>
    public event EventHandler<Efl.Ui.Spotlight.ContainerTransitionEndEvt_Args> TransitionEndEvt
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
                        Efl.Ui.Spotlight.ContainerTransitionEndEvt_Args args = new Efl.Ui.Spotlight.ContainerTransitionEndEvt_Args();
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

                string key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_END";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_END";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event TransitionEndEvt.</summary>
    public void OnTransitionEndEvt(Efl.Ui.Spotlight.ContainerTransitionEndEvt_Args e)
    {
        var key = "_EFL_UI_SPOTLIGHT_EVENT_TRANSITION_END";
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
    /// <summary>This object defines how sub-widgets are rendered and animated. If it is not set, only the active sub-widget is shown and transitions are instantaneous (not animated).</summary>
    /// <returns>The Spotlight Manager object or <c>NULL</c>.</returns>
    virtual public Efl.Ui.Spotlight.Manager GetSpotlightManager() {
         var _ret_var = Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_manager_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This object defines how sub-widgets are rendered and animated. If it is not set, only the active sub-widget is shown and transitions are instantaneous (not animated).</summary>
    /// <param name="spotlight_manager">The Spotlight Manager object or <c>NULL</c>.</param>
    virtual public void SetSpotlightManager(Efl.Ui.Spotlight.Manager spotlight_manager) {
                                 Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_manager_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),spotlight_manager);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>An indicator object to use, which will display the current state of the spotlight (number of sub-widgets and active one). When this object is set, it is immediately updated to reflect the current state of the widget. Its location inside the container is controlled by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/>.</summary>
    /// <returns>The Indicator object or <c>NULL</c>.</returns>
    virtual public Efl.Ui.Spotlight.Indicator GetIndicator() {
         var _ret_var = Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_indicator_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>An indicator object to use, which will display the current state of the spotlight (number of sub-widgets and active one). When this object is set, it is immediately updated to reflect the current state of the widget. Its location inside the container is controlled by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/>.</summary>
    /// <param name="indicator">The Indicator object or <c>NULL</c>.</param>
    virtual public void SetIndicator(Efl.Ui.Spotlight.Indicator indicator) {
                                 Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_indicator_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),indicator);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
    /// Changing this value might trigger an animation.</summary>
    /// <returns>Index of the sub-widget that has the spotlight, from 0 to the number of sub-widgets - 1 (<see cref="Efl.IContainer.ContentCount"/> - 1).</returns>
    virtual public int GetActiveIndex() {
         var _ret_var = Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_active_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
    /// Changing this value might trigger an animation.</summary>
    /// <param name="index">Index of the sub-widget that has the spotlight, from 0 to the number of sub-widgets - 1 (<see cref="Efl.IContainer.ContentCount"/> - 1).</param>
    virtual public void SetActiveIndex(int index) {
                                 Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_active_index_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
    /// <returns>Render size for the spotlight. (-1, -1) means that all available space inside the container is used.</returns>
    virtual public Eina.Size2D GetSpotlightSize() {
         var _ret_var = Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
    /// <param name="size">Render size for the spotlight. (-1, -1) means that all available space inside the container is used.</param>
    virtual public void SetSpotlightSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Packs a new sub-widget at the position indicated by <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/> (0 by default).
    /// This is the same behavior as a push operation on a stack.
    /// 
    /// An animation might be triggered to give the new sub-widget the spotlight and come into position.</summary>
    /// <param name="widget">Sub-Widget to add and set to be the spotlight sub-widget.</param>
    virtual public void Push(Efl.Gfx.IEntity widget) {
                                 Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_push_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),widget);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes the sub-widget that has the spotlight from the widget.
    /// The sub-widgets behind it naturally flow down so the next one gets the spotlight. This is the same behavior as a pop operation on a stack. When combined with <see cref="Efl.Ui.Spotlight.Container.Push"/> you don&apos;t have to worry about <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/> since only the first sub-widget is manipulated.
    /// 
    /// An animation might be triggered to give the new sub-widget the spotlight, come into position and the old one disappear.
    /// 
    /// The removed sub-widget can be returned to the caller or deleted (depending on <c>delete_on_transition_end</c>).</summary>
    /// <param name="deletion_on_transition_end">if <c>true</c>, then the object will be deleted before resolving the future, and a NULL pointer is the value of the future. <c>false</c> if no operation should be applied to it</param>
    /// <returns>This Future gets resolved when any transition animation finishes and the popped sub-widget is ready for collection. If there is no animation, the Future resolves immediately. If <c>deletion_on_transition_end</c> is <c>true</c> then this widget will destroy the popped sub-widget and the Future will contain no Value. Otherwise, the caller becomes the owner of the sub-widget contained in the Future and must dispose of it appropriately.</returns>
    virtual public  Eina.Future Pop(bool deletion_on_transition_end) {
                                 var _ret_var = Efl.Ui.Spotlight.Container.NativeMethods.efl_ui_spotlight_pop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),deletion_on_transition_end);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool ClearPack() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool UnpackAll() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    virtual public bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend an object at the beginning of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, 0).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the beginning.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBegin(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_begin_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Append object at the end of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, -1).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the end.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackEnd(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend an object before an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack before <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBefore(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_before_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Append an object after an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack after <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAfter(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_after_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will trigger <see cref="Efl.IPackLinear.PackBegin"/>(<c>subobj</c>) whereas <c>index</c> greater than <c>count</c>-1 will trigger <see cref="Efl.IPackLinear.PackEnd"/>(<c>subobj</c>).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack.</param>
    /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAt(Efl.Gfx.IEntity subobj, int index) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sub-object at a given <c>index</c> in this container.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will return the last sub-object.</summary>
    /// <param name="index">Index of the existing sub-object to retrieve. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The sub-object contained at the given <c>index</c>.</returns>
    virtual public Efl.Gfx.IEntity GetPackContent(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the index of a sub-object in this container.</summary>
    /// <param name="subobj">An existing sub-object in this container.</param>
    /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range 0 to (<c>count</c>-1).</returns>
    virtual public int GetPackIndex(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
    /// <param name="index">Index of the sub-object to remove. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The sub-object if it could be removed.</returns>
    virtual public Efl.Gfx.IEntity PackUnpackAt(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Async wrapper for <see cref="Pop" />.</summary>
    /// <param name="deletion_on_transition_end">if <c>true</c>, then the object will be deleted before resolving the future, and a NULL pointer is the value of the future. <c>false</c> if no operation should be applied to it</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> PopAsync(bool deletion_on_transition_end, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = Pop( deletion_on_transition_end);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>This object defines how sub-widgets are rendered and animated. If it is not set, only the active sub-widget is shown and transitions are instantaneous (not animated).</summary>
    /// <value>The Spotlight Manager object or <c>NULL</c>.</value>
    public Efl.Ui.Spotlight.Manager SpotlightManager {
        get { return GetSpotlightManager(); }
        set { SetSpotlightManager(value); }
    }
    /// <summary>An indicator object to use, which will display the current state of the spotlight (number of sub-widgets and active one). When this object is set, it is immediately updated to reflect the current state of the widget. Its location inside the container is controlled by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/>.</summary>
    /// <value>The Indicator object or <c>NULL</c>.</value>
    public Efl.Ui.Spotlight.Indicator Indicator {
        get { return GetIndicator(); }
        set { SetIndicator(value); }
    }
    /// <summary>Currently active sub-widget (the one with the spotlight) among all the sub-widgets added to this widget
    /// Changing this value might trigger an animation.</summary>
    /// <value>Index of the sub-widget that has the spotlight, from 0 to the number of sub-widgets - 1 (<see cref="Efl.IContainer.ContentCount"/> - 1).</value>
    public int ActiveIndex {
        get { return GetActiveIndex(); }
        set { SetActiveIndex(value); }
    }
    /// <summary>The size to use when displaying the Sub-Widget which has the spotlight. This is used by the <see cref="Efl.Ui.Spotlight.Container.SpotlightManager"/> to perform the rendering. Sub-Widgets other than the Active one may or may not use this size.</summary>
    /// <value>Render size for the spotlight. (-1, -1) means that all available space inside the container is used.</value>
    public Eina.Size2D SpotlightSize {
        get { return GetSpotlightSize(); }
        set { SetSpotlightSize(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Spotlight.Container.efl_ui_spotlight_container_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_spotlight_manager_get_static_delegate == null)
            {
                efl_ui_spotlight_manager_get_static_delegate = new efl_ui_spotlight_manager_get_delegate(spotlight_manager_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSpotlightManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_get_static_delegate) });
            }

            if (efl_ui_spotlight_manager_set_static_delegate == null)
            {
                efl_ui_spotlight_manager_set_static_delegate = new efl_ui_spotlight_manager_set_delegate(spotlight_manager_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSpotlightManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_set_static_delegate) });
            }

            if (efl_ui_spotlight_indicator_get_static_delegate == null)
            {
                efl_ui_spotlight_indicator_get_static_delegate = new efl_ui_spotlight_indicator_get_delegate(indicator_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndicator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_indicator_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_indicator_get_static_delegate) });
            }

            if (efl_ui_spotlight_indicator_set_static_delegate == null)
            {
                efl_ui_spotlight_indicator_set_static_delegate = new efl_ui_spotlight_indicator_set_delegate(indicator_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIndicator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_indicator_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_indicator_set_static_delegate) });
            }

            if (efl_ui_spotlight_active_index_get_static_delegate == null)
            {
                efl_ui_spotlight_active_index_get_static_delegate = new efl_ui_spotlight_active_index_get_delegate(active_index_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActiveIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_active_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_active_index_get_static_delegate) });
            }

            if (efl_ui_spotlight_active_index_set_static_delegate == null)
            {
                efl_ui_spotlight_active_index_set_static_delegate = new efl_ui_spotlight_active_index_set_delegate(active_index_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetActiveIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_active_index_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_active_index_set_static_delegate) });
            }

            if (efl_ui_spotlight_size_get_static_delegate == null)
            {
                efl_ui_spotlight_size_get_static_delegate = new efl_ui_spotlight_size_get_delegate(spotlight_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSpotlightSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_size_get_static_delegate) });
            }

            if (efl_ui_spotlight_size_set_static_delegate == null)
            {
                efl_ui_spotlight_size_set_static_delegate = new efl_ui_spotlight_size_set_delegate(spotlight_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSpotlightSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_size_set_static_delegate) });
            }

            if (efl_ui_spotlight_push_static_delegate == null)
            {
                efl_ui_spotlight_push_static_delegate = new efl_ui_spotlight_push_delegate(push);
            }

            if (methods.FirstOrDefault(m => m.Name == "Push") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_push_static_delegate) });
            }

            if (efl_ui_spotlight_pop_static_delegate == null)
            {
                efl_ui_spotlight_pop_static_delegate = new efl_ui_spotlight_pop_delegate(pop);
            }

            if (methods.FirstOrDefault(m => m.Name == "Pop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_pop_static_delegate) });
            }

            if (efl_pack_clear_static_delegate == null)
            {
                efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearPack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate) });
            }

            if (efl_pack_unpack_all_static_delegate == null)
            {
                efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnpackAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate) });
            }

            if (efl_pack_unpack_static_delegate == null)
            {
                efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate) });
            }

            if (efl_pack_static_delegate == null)
            {
                efl_pack_static_delegate = new efl_pack_delegate(pack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Pack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate) });
            }

            if (efl_pack_begin_static_delegate == null)
            {
                efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackBegin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate) });
            }

            if (efl_pack_end_static_delegate == null)
            {
                efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate) });
            }

            if (efl_pack_before_static_delegate == null)
            {
                efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackBefore") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate) });
            }

            if (efl_pack_after_static_delegate == null)
            {
                efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackAfter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate) });
            }

            if (efl_pack_at_static_delegate == null)
            {
                efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackAt") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate) });
            }

            if (efl_pack_content_get_static_delegate == null)
            {
                efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate) });
            }

            if (efl_pack_index_get_static_delegate == null)
            {
                efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate) });
            }

            if (efl_pack_unpack_at_static_delegate == null)
            {
                efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackUnpackAt") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Spotlight.Container.efl_ui_spotlight_container_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.Ui.Spotlight.Manager efl_ui_spotlight_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.Ui.Spotlight.Manager efl_ui_spotlight_manager_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_get_api_delegate> efl_ui_spotlight_manager_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_get_api_delegate>(Module, "efl_ui_spotlight_manager_get");

        private static Efl.Ui.Spotlight.Manager spotlight_manager_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Spotlight.Manager _ret_var = default(Efl.Ui.Spotlight.Manager);
                try
                {
                    _ret_var = ((Container)ws.Target).GetSpotlightManager();
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
                return efl_ui_spotlight_manager_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_manager_get_delegate efl_ui_spotlight_manager_get_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))] Efl.Ui.Spotlight.Manager spotlight_manager);

        
        public delegate void efl_ui_spotlight_manager_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))] Efl.Ui.Spotlight.Manager spotlight_manager);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_set_api_delegate> efl_ui_spotlight_manager_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_set_api_delegate>(Module, "efl_ui_spotlight_manager_set");

        private static void spotlight_manager_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Spotlight.Manager spotlight_manager)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Container)ws.Target).SetSpotlightManager(spotlight_manager);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_manager_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), spotlight_manager);
            }
        }

        private static efl_ui_spotlight_manager_set_delegate efl_ui_spotlight_manager_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.Ui.Spotlight.Indicator efl_ui_spotlight_indicator_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.Ui.Spotlight.Indicator efl_ui_spotlight_indicator_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_indicator_get_api_delegate> efl_ui_spotlight_indicator_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_indicator_get_api_delegate>(Module, "efl_ui_spotlight_indicator_get");

        private static Efl.Ui.Spotlight.Indicator indicator_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_indicator_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Spotlight.Indicator _ret_var = default(Efl.Ui.Spotlight.Indicator);
                try
                {
                    _ret_var = ((Container)ws.Target).GetIndicator();
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
                return efl_ui_spotlight_indicator_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_indicator_get_delegate efl_ui_spotlight_indicator_get_static_delegate;

        
        private delegate void efl_ui_spotlight_indicator_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))] Efl.Ui.Spotlight.Indicator indicator);

        
        public delegate void efl_ui_spotlight_indicator_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))] Efl.Ui.Spotlight.Indicator indicator);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_indicator_set_api_delegate> efl_ui_spotlight_indicator_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_indicator_set_api_delegate>(Module, "efl_ui_spotlight_indicator_set");

        private static void indicator_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Spotlight.Indicator indicator)
        {
            Eina.Log.Debug("function efl_ui_spotlight_indicator_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Container)ws.Target).SetIndicator(indicator);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_indicator_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), indicator);
            }
        }

        private static efl_ui_spotlight_indicator_set_delegate efl_ui_spotlight_indicator_set_static_delegate;

        
        private delegate int efl_ui_spotlight_active_index_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_spotlight_active_index_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_active_index_get_api_delegate> efl_ui_spotlight_active_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_active_index_get_api_delegate>(Module, "efl_ui_spotlight_active_index_get");

        private static int active_index_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_active_index_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Container)ws.Target).GetActiveIndex();
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
                return efl_ui_spotlight_active_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_active_index_get_delegate efl_ui_spotlight_active_index_get_static_delegate;

        
        private delegate void efl_ui_spotlight_active_index_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        
        public delegate void efl_ui_spotlight_active_index_set_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_active_index_set_api_delegate> efl_ui_spotlight_active_index_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_active_index_set_api_delegate>(Module, "efl_ui_spotlight_active_index_set");

        private static void active_index_set(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_ui_spotlight_active_index_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Container)ws.Target).SetActiveIndex(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_active_index_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_ui_spotlight_active_index_set_delegate efl_ui_spotlight_active_index_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_spotlight_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_spotlight_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_size_get_api_delegate> efl_ui_spotlight_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_size_get_api_delegate>(Module, "efl_ui_spotlight_size_get");

        private static Eina.Size2D.NativeStruct spotlight_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Container)ws.Target).GetSpotlightSize();
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
                return efl_ui_spotlight_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_size_get_delegate efl_ui_spotlight_size_get_static_delegate;

        
        private delegate void efl_ui_spotlight_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_ui_spotlight_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_size_set_api_delegate> efl_ui_spotlight_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_size_set_api_delegate>(Module, "efl_ui_spotlight_size_set");

        private static void spotlight_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_ui_spotlight_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((Container)ws.Target).SetSpotlightSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_ui_spotlight_size_set_delegate efl_ui_spotlight_size_set_static_delegate;

        
        private delegate void efl_ui_spotlight_push_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity widget);

        
        public delegate void efl_ui_spotlight_push_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity widget);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_push_api_delegate> efl_ui_spotlight_push_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_push_api_delegate>(Module, "efl_ui_spotlight_push");

        private static void push(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity widget)
        {
            Eina.Log.Debug("function efl_ui_spotlight_push was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Container)ws.Target).Push(widget);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_push_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), widget);
            }
        }

        private static efl_ui_spotlight_push_delegate efl_ui_spotlight_push_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_spotlight_pop_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool deletion_on_transition_end);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_spotlight_pop_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool deletion_on_transition_end);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_pop_api_delegate> efl_ui_spotlight_pop_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_pop_api_delegate>(Module, "efl_ui_spotlight_pop");

        private static  Eina.Future pop(System.IntPtr obj, System.IntPtr pd, bool deletion_on_transition_end)
        {
            Eina.Log.Debug("function efl_ui_spotlight_pop was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                     Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Container)ws.Target).Pop(deletion_on_transition_end);
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
                return efl_ui_spotlight_pop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), deletion_on_transition_end);
            }
        }

        private static efl_ui_spotlight_pop_delegate efl_ui_spotlight_pop_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(Module, "efl_pack_clear");

        private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).ClearPack();
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
                return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_clear_delegate efl_pack_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(Module, "efl_pack_unpack_all");

        private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_unpack_all was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).UnpackAll();
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
                return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(Module, "efl_pack_unpack");

        private static bool unpack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_unpack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).Unpack(subobj);
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
                return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(Module, "efl_pack");

        private static bool pack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).Pack(subobj);
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
                return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_delegate efl_pack_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate>(Module, "efl_pack_begin");

        private static bool pack_begin(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_begin was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).PackBegin(subobj);
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
                return efl_pack_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_begin_delegate efl_pack_begin_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate>(Module, "efl_pack_end");

        private static bool pack_end(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).PackEnd(subobj);
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
                return efl_pack_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_end_delegate efl_pack_end_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        public static Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate>(Module, "efl_pack_before");

        private static bool pack_before(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing)
        {
            Eina.Log.Debug("function efl_pack_before was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).PackBefore(subobj, existing);
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
                return efl_pack_before_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, existing);
            }
        }

        private static efl_pack_before_delegate efl_pack_before_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        public static Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate>(Module, "efl_pack_after");

        private static bool pack_after(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing)
        {
            Eina.Log.Debug("function efl_pack_after was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).PackAfter(subobj, existing);
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
                return efl_pack_after_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, existing);
            }
        }

        private static efl_pack_after_delegate efl_pack_after_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate>(Module, "efl_pack_at");

        private static bool pack_at(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int index)
        {
            Eina.Log.Debug("function efl_pack_at was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Container)ws.Target).PackAt(subobj, index);
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
                return efl_pack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, index);
            }
        }

        private static efl_pack_at_delegate efl_pack_at_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_pack_content_get_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate>(Module, "efl_pack_content_get");

        private static Efl.Gfx.IEntity pack_content_get(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_pack_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Container)ws.Target).GetPackContent(index);
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
                return efl_pack_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;

        
        private delegate int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        
        public delegate int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate>(Module, "efl_pack_index_get");

        private static int pack_index_get(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_index_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Container)ws.Target).GetPackIndex(subobj);
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
                return efl_pack_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_pack_unpack_at_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate>(Module, "efl_pack_unpack_at");

        private static Efl.Gfx.IEntity pack_unpack_at(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_pack_unpack_at was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Container)ws.Target).PackUnpackAt(index);
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
                return efl_pack_unpack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_SpotlightContainer_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.Spotlight.Manager> SpotlightManager<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Spotlight.Container, T>magic = null) where T : Efl.Ui.Spotlight.Container {
        return new Efl.BindableProperty<Efl.Ui.Spotlight.Manager>("spotlight_manager", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Spotlight.Indicator> Indicator<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Spotlight.Container, T>magic = null) where T : Efl.Ui.Spotlight.Container {
        return new Efl.BindableProperty<Efl.Ui.Spotlight.Indicator>("indicator", fac);
    }

    public static Efl.BindableProperty<int> ActiveIndex<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Spotlight.Container, T>magic = null) where T : Efl.Ui.Spotlight.Container {
        return new Efl.BindableProperty<int>("active_index", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> SpotlightSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Spotlight.Container, T>magic = null) where T : Efl.Ui.Spotlight.Container {
        return new Efl.BindableProperty<Eina.Size2D>("spotlight_size", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

namespace Spotlight {

/// <summary>Information regarding transition events.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct TransitionEvent
{
    /// <summary>The index from where the transition started, -1 if not known.</summary>
    public int From;
    /// <summary>The index to where the transition is headed, -1 if not known.</summary>
    public int To;
    /// <summary>Constructor for TransitionEvent.</summary>
    /// <param name="From">The index from where the transition started, -1 if not known.</param>;
    /// <param name="To">The index to where the transition is headed, -1 if not known.</param>;
    public TransitionEvent(
        int From = default(int),
        int To = default(int)    )
    {
        this.From = From;
        this.To = To;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator TransitionEvent(IntPtr ptr)
    {
        var tmp = (TransitionEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(TransitionEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct TransitionEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int From;
        
        public int To;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator TransitionEvent.NativeStruct(TransitionEvent _external_struct)
        {
            var _internal_struct = new TransitionEvent.NativeStruct();
            _internal_struct.From = _external_struct.From;
            _internal_struct.To = _external_struct.To;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator TransitionEvent(TransitionEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new TransitionEvent();
            _external_struct.From = _internal_struct.From;
            _external_struct.To = _internal_struct.To;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

