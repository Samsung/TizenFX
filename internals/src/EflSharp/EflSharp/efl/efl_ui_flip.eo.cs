#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI flip class</summary>
[Efl.Ui.Flip.NativeMethods]
public class Flip : Efl.Ui.Widget, Efl.Eo.IWrapper,Efl.IContainer,Efl.IPack,Efl.IPackLinear
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Flip))
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
        efl_ui_flip_class_get();
    /// <summary>Initializes a new instance of the <see cref="Flip"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Flip(Efl.Object parent
            , System.String style = null) : base(efl_ui_flip_class_get(), typeof(Flip), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Flip"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Flip(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Flip"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Flip(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Called when flip animation begins</summary>
    public event EventHandler AnimateBeginEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_FLIP_EVENT_ANIMATE_BEGIN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_FLIP_EVENT_ANIMATE_BEGIN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnimateBeginEvt.</summary>
    public void OnAnimateBeginEvt(EventArgs e)
    {
        var key = "_EFL_UI_FLIP_EVENT_ANIMATE_BEGIN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when flip animation is done</summary>
    public event EventHandler AnimateDoneEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_FLIP_EVENT_ANIMATE_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_FLIP_EVENT_ANIMATE_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnimateDoneEvt.</summary>
    public void OnAnimateDoneEvt(EventArgs e)
    {
        var key = "_EFL_UI_FLIP_EVENT_ANIMATE_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Sent after a new item was added.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentAddedEvt_Args> ContentAddedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.IContainerContentAddedEvt_Args args = new Efl.IContainerContentAddedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ContentAddedEvt.</summary>
    public void OnContentAddedEvt(Efl.IContainerContentAddedEvt_Args e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after an item was removed, before unref.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentRemovedEvt_Args> ContentRemovedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.IContainerContentRemovedEvt_Args args = new Efl.IContainerContentRemovedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ContentRemovedEvt.</summary>
    public void OnContentRemovedEvt(Efl.IContainerContentRemovedEvt_Args e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Get the interactive flip mode.</summary>
    /// <returns>The interactive flip mode to use.</returns>
    virtual public Efl.Ui.FlipInteraction GetInteraction() {
         var _ret_var = Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the interactive flip mode.
    /// This sets if the flip should be interactive (allow user to click and drag a side of the flip to reveal the back page and cause it to flip). By default a flip is not interactive. You may also need to set which sides of the flip are &quot;active&quot; for flipping and how much space they use (a minimum of a finger size) with <see cref="Efl.Ui.Flip.SetInteractionDirectionEnabled"/> and <see cref="Efl.Ui.Flip.SetInteractionDirectionHitsize"/>.
    /// 
    /// The four available mode of interaction are #ELM_FLIP_INTERACTION_NONE, #ELM_FLIP_INTERACTION_ROTATE, #ELM_FLIP_INTERACTION_CUBE and  #ELM_FLIP_INTERACTION_PAGE.
    /// 
    /// Note: #ELM_FLIP_INTERACTION_ROTATE won&apos;t cause #ELM_FLIP_ROTATE_XZ_CENTER_AXIS or #ELM_FLIP_ROTATE_YZ_CENTER_AXIS to happen, those can only be achieved with <see cref="Efl.Ui.Flip.Go"/>.</summary>
    /// <param name="mode">The interactive flip mode to use.</param>
    virtual public void SetInteraction(Efl.Ui.FlipInteraction mode) {
                                 Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get flip front visibility state.</summary>
    /// <returns><c>true</c> if front front is showing, <c>false</c> if the back is showing.</returns>
    virtual public bool GetFrontVisible() {
         var _ret_var = Efl.Ui.Flip.NativeMethods.efl_ui_flip_front_visible_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the amount of the flip that is sensitive to interactive flip.
    /// Set the amount of the flip that is sensitive to interactive flip, with 0 representing no area in the flip and 1 representing the entire flip. There is however a consideration to be made in that the area will never be smaller than the finger size set (as set in your Elementary configuration), and dragging must always start from the opposite half of the flip (eg. right half of the flip when dragging to the left).
    /// 
    /// Note: The <c>dir</c> parameter is not actually related to the direction of the drag, it only refers to the area in the flip where interaction can occur (top, bottom, left, right).
    /// 
    /// Negative values of <c>hitsize</c> will disable this hit area.
    /// 
    /// See also <see cref="Efl.Ui.Flip.SetInteraction"/>.</summary>
    /// <param name="dir">The hit area to set.</param>
    /// <param name="hitsize">The amount of that dimension (0.0 to 1.0) to use.</param>
    virtual public void SetInteractionDirectionHitsize(Efl.Ui.Dir dir, double hitsize) {
                                                         Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_direction_hitsize_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir, hitsize);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the amount of the flip that is sensitive to interactive flip.</summary>
    /// <param name="dir">The direction to check.</param>
    /// <returns>The size set for that direction.</returns>
    virtual public double GetInteractionDirectionHitsize(Efl.Ui.Dir dir) {
                                 var _ret_var = Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_direction_hitsize_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set which directions of the flip respond to interactive flip
    /// By default all directions are disabled, so you may want to enable the desired directions for flipping if you need interactive flipping. You must call this function once for each direction that&apos;s enabled.
    /// 
    /// You can also set the appropriate hit area size by calling <see cref="Efl.Ui.Flip.SetInteractionDirectionHitsize"/>. By default, a minimum hit area will be created on the opposite edge of the flip.</summary>
    /// <param name="dir">The direction to change.</param>
    /// <param name="enabled">If that direction is enabled or not.</param>
    virtual public void SetInteractionDirectionEnabled(Efl.Ui.Dir dir, bool enabled) {
                                                         Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_direction_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir, enabled);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the enabled state of that flip direction.</summary>
    /// <param name="dir">The direction to check.</param>
    /// <returns>If that direction is enabled or not.</returns>
    virtual public bool GetInteractionDirectionEnabled(Efl.Ui.Dir dir) {
                                 var _ret_var = Efl.Ui.Flip.NativeMethods.efl_ui_flip_interaction_direction_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Runs the flip animation.
    /// Flips the front and back contents using the <c>mode</c> animation. This effectively hides the currently visible content and shows the hidden one.
    /// 
    /// There a number of possible animations to use for flipping, namely #ELM_FLIP_ROTATE_X_CENTER_AXIS (rotate the currently visible content around a horizontal axis in the middle of its height, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_Y_CENTER_AXIS (rotate the currently visible content around a vertical axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_XZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_YZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its height, the other content is shown as the other side of the flip). #ELM_FLIP_CUBE_LEFT (rotate the currently visible content to the left as if the flip was a cube, the other content is shown as the right face of the cube), #ELM_FLIP_CUBE_RIGHT (rotate the currently visible content to the right as if the flip was a cube, the other content is shown as the left face of the cube), #ELM_FLIP_CUBE_UP (rotate the currently visible content up as if the flip was a cube, the other content is shown as the bottom face of the cube), #ELM_FLIP_CUBE_DOWN (rotate the currently visible content down as if the flip was a cube, the other content is shown as the upper face of the cube), #ELM_FLIP_PAGE_LEFT (move the currently visible content to the left as if the flip was a book, the other content is shown as the page below that), #ELM_FLIP_PAGE_RIGHT (move the currently visible content to the right as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_UP (move the currently visible content up as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_DOWN (move the currently visible content down as if the flip was a book, the other content is shown as the page below that) and #ELM_FLIP_CROSS_FADE (fade out the currently visible content, while fading in the invisible content).</summary>
    /// <param name="mode">The mode type.</param>
    virtual public void Go(Efl.Ui.FlipMode mode) {
                                 Efl.Ui.Flip.NativeMethods.efl_ui_flip_go_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Runs the flip animation to front or back.
    /// Flips the front and back contents using the <c>mode</c> animation. This effectively hides the currently visible content and shows he hidden one.
    /// 
    /// There a number of possible animations to use for flipping, namely #ELM_FLIP_ROTATE_X_CENTER_AXIS (rotate the currently visible content around a horizontal axis in the middle of its height, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_Y_CENTER_AXIS (rotate the currently visible content around a vertical axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_XZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its width, the other content is shown as the other side of the flip), #ELM_FLIP_ROTATE_YZ_CENTER_AXIS (rotate the currently visible content around a diagonal axis in the middle of its height, the other content is shown as the other side of the flip). #ELM_FLIP_CUBE_LEFT (rotate the currently visible content to the left as if the flip was a cube, the other content is show as the right face of the cube), #ELM_FLIP_CUBE_RIGHT (rotate the currently visible content to the right as if the flip was a cube, the other content is show as the left face of the cube), #ELM_FLIP_CUBE_UP (rotate the currently visible content up as if the flip was a cube, the other content is shown as the bottom face of the cube), #ELM_FLIP_CUBE_DOWN (rotate the currently visible content down as if the flip was a cube, the other content is shown as the upper face of the cube), #ELM_FLIP_PAGE_LEFT (move the currently visible content to the left as if the flip was a book, the other content is shown as the page below that), #ELM_FLIP_PAGE_RIGHT (move the currently visible content to the right as if the flip was a book, the other content is shown as the page below it), #ELM_FLIP_PAGE_UP (move the currently visible content up as if the flip was a book, the other content is shown as the page below it) and #ELM_FLIP_PAGE_DOWN (move the currently visible content down as if the flip was a book, the other content is shown as the page below that).</summary>
    /// <param name="front">If <c>true</c>, makes front visible, otherwise makes back.</param>
    /// <param name="mode">The mode type.</param>
    virtual public void GoTo(bool front, Efl.Ui.FlipMode mode) {
                                                         Efl.Ui.Flip.NativeMethods.efl_ui_flip_go_to_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),front, mode);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator to object content</returns>
    virtual public Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.IContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Returns the number of UI elements packed in this container.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of packed UI elements</returns>
    virtual public int ContentCount() {
         var _ret_var = Efl.IContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void GetPackAlign(out double align_horiz, out double align_vert) {
                                                         Efl.IPackConcrete.NativeMethods.efl_pack_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void SetPackAlign(double align_horiz, double align_vert) {
                                                         Efl.IPackConcrete.NativeMethods.efl_pack_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void GetPackPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.IPackConcrete.NativeMethods.efl_pack_padding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void SetPackPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.IPackConcrete.NativeMethods.efl_pack_padding_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Removes all packed contents, and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool ClearPack() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed contents, without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool UnpackAll() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing item from the container, without deleting it.</summary>
    /// <param name="subobj">The unpacked object.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t a child or can&apos;t be removed</returns>
    virtual public bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds an item to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">An object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend an object at the beginning of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, 0).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack at the beginning.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBegin(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Append item at the end of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, -1).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack at the end.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackEnd(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend item before other sub object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack before <c>existing</c>.</param>
    /// <param name="existing">Item to refer to.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBefore(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_before_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Append item after other sub object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack after <c>existing</c>.</param>
    /// <param name="existing">Item to refer to.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAfter(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_after_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Inserts <c>subobj</c> BEFORE the item at position <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first item (0) to last item (<c>count</c>-1), and negative numbers go from last item (-1) to first item (-<c>count</c>). Where <c>count</c> is the number of items currently in the container.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will trigger <see cref="Efl.IPackLinear.PackBegin"/>(<c>subobj</c>) whereas <c>index</c> greater than <c>count</c>-1 will trigger <see cref="Efl.IPackLinear.PackEnd"/>(<c>subobj</c>).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack.</param>
    /// <param name="index">Index of item to insert BEFORE. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAt(Efl.Gfx.IEntity subobj, int index) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Content at a given <c>index</c> in this container.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first item (0) to last item (<c>count</c>-1), and negative numbers go from last item (-1) to first item (-<c>count</c>). Where <c>count</c> is the number of items currently in the container.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will return the first item whereas <c>index</c> greater than <c>count</c>-1 will return the last item.</summary>
    /// <param name="index">Index of the item to retrieve. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The object contained at the given <c>index</c>.</returns>
    virtual public Efl.Gfx.IEntity GetPackContent(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the index of a child in this container.</summary>
    /// <param name="subobj">An object contained in this pack.</param>
    /// <returns>-1 in case <c>subobj</c> is not a child of this object, or the index of this item in the range 0 to (<c>count</c>-1).</returns>
    virtual public int GetPackIndex(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Pop out (remove) the item at the specified <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first item (0) to last item (<c>count</c>-1), and negative numbers go from last item (-1) to first item (-<c>count</c>). Where <c>count</c> is the number of items currently in the container.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will remove the first item whereas <c>index</c> greater than <c>count</c>-1 will remove the last item.
    /// 
    /// Equivalent to <see cref="Efl.IPack.Unpack"/>(<see cref="Efl.IPackLinear.GetPackContent"/>(<c>index</c>)).</summary>
    /// <param name="index">Index of item to remove. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The child item if it could be removed.</returns>
    virtual public Efl.Gfx.IEntity PackUnpackAt(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the interactive flip mode.</summary>
/// <value>The interactive flip mode to use.</value>
    public Efl.Ui.FlipInteraction Interaction {
        get { return GetInteraction(); }
        set { SetInteraction(value); }
    }
    /// <summary>Get flip front visibility state.</summary>
/// <value><c>true</c> if front front is showing, <c>false</c> if the back is showing.</value>
    public bool FrontVisible {
        get { return GetFrontVisible(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Flip.efl_ui_flip_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_flip_interaction_get_static_delegate == null)
            {
                efl_ui_flip_interaction_get_static_delegate = new efl_ui_flip_interaction_get_delegate(interaction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInteraction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_get_static_delegate) });
            }

            if (efl_ui_flip_interaction_set_static_delegate == null)
            {
                efl_ui_flip_interaction_set_static_delegate = new efl_ui_flip_interaction_set_delegate(interaction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInteraction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_set_static_delegate) });
            }

            if (efl_ui_flip_front_visible_get_static_delegate == null)
            {
                efl_ui_flip_front_visible_get_static_delegate = new efl_ui_flip_front_visible_get_delegate(front_visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrontVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_front_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_front_visible_get_static_delegate) });
            }

            if (efl_ui_flip_interaction_direction_hitsize_set_static_delegate == null)
            {
                efl_ui_flip_interaction_direction_hitsize_set_static_delegate = new efl_ui_flip_interaction_direction_hitsize_set_delegate(interaction_direction_hitsize_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInteractionDirectionHitsize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_direction_hitsize_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_hitsize_set_static_delegate) });
            }

            if (efl_ui_flip_interaction_direction_hitsize_get_static_delegate == null)
            {
                efl_ui_flip_interaction_direction_hitsize_get_static_delegate = new efl_ui_flip_interaction_direction_hitsize_get_delegate(interaction_direction_hitsize_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInteractionDirectionHitsize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_direction_hitsize_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_hitsize_get_static_delegate) });
            }

            if (efl_ui_flip_interaction_direction_enabled_set_static_delegate == null)
            {
                efl_ui_flip_interaction_direction_enabled_set_static_delegate = new efl_ui_flip_interaction_direction_enabled_set_delegate(interaction_direction_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInteractionDirectionEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_direction_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_enabled_set_static_delegate) });
            }

            if (efl_ui_flip_interaction_direction_enabled_get_static_delegate == null)
            {
                efl_ui_flip_interaction_direction_enabled_get_static_delegate = new efl_ui_flip_interaction_direction_enabled_get_delegate(interaction_direction_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInteractionDirectionEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_interaction_direction_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_interaction_direction_enabled_get_static_delegate) });
            }

            if (efl_ui_flip_go_static_delegate == null)
            {
                efl_ui_flip_go_static_delegate = new efl_ui_flip_go_delegate(go);
            }

            if (methods.FirstOrDefault(m => m.Name == "Go") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_go_static_delegate) });
            }

            if (efl_ui_flip_go_to_static_delegate == null)
            {
                efl_ui_flip_go_to_static_delegate = new efl_ui_flip_go_to_delegate(go_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "GoTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_flip_go_to"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_flip_go_to_static_delegate) });
            }

            if (efl_content_iterate_static_delegate == null)
            {
                efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "ContentIterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate) });
            }

            if (efl_content_count_static_delegate == null)
            {
                efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "ContentCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate) });
            }

            if (efl_pack_align_get_static_delegate == null)
            {
                efl_pack_align_get_static_delegate = new efl_pack_align_get_delegate(pack_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_get_static_delegate) });
            }

            if (efl_pack_align_set_static_delegate == null)
            {
                efl_pack_align_set_static_delegate = new efl_pack_align_set_delegate(pack_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPackAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_set_static_delegate) });
            }

            if (efl_pack_padding_get_static_delegate == null)
            {
                efl_pack_padding_get_static_delegate = new efl_pack_padding_get_delegate(pack_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_get_static_delegate) });
            }

            if (efl_pack_padding_set_static_delegate == null)
            {
                efl_pack_padding_set_static_delegate = new efl_pack_padding_set_delegate(pack_padding_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPackPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_set_static_delegate) });
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
            return Efl.Ui.Flip.efl_ui_flip_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Efl.Ui.FlipInteraction efl_ui_flip_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.FlipInteraction efl_ui_flip_interaction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_get_api_delegate> efl_ui_flip_interaction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_get_api_delegate>(Module, "efl_ui_flip_interaction_get");

        private static Efl.Ui.FlipInteraction interaction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Ui.FlipInteraction _ret_var = default(Efl.Ui.FlipInteraction);
                try
                {
                    _ret_var = ((Flip)wrapper).GetInteraction();
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
                return efl_ui_flip_interaction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_flip_interaction_get_delegate efl_ui_flip_interaction_get_static_delegate;

        
        private delegate void efl_ui_flip_interaction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.FlipInteraction mode);

        
        public delegate void efl_ui_flip_interaction_set_api_delegate(System.IntPtr obj,  Efl.Ui.FlipInteraction mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_set_api_delegate> efl_ui_flip_interaction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_set_api_delegate>(Module, "efl_ui_flip_interaction_set");

        private static void interaction_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.FlipInteraction mode)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Flip)wrapper).SetInteraction(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_flip_interaction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_flip_interaction_set_delegate efl_ui_flip_interaction_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_flip_front_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_flip_front_visible_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_front_visible_get_api_delegate> efl_ui_flip_front_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_front_visible_get_api_delegate>(Module, "efl_ui_flip_front_visible_get");

        private static bool front_visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_flip_front_visible_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).GetFrontVisible();
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
                return efl_ui_flip_front_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_flip_front_visible_get_delegate efl_ui_flip_front_visible_get_static_delegate;

        
        private delegate void efl_ui_flip_interaction_direction_hitsize_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir,  double hitsize);

        
        public delegate void efl_ui_flip_interaction_direction_hitsize_set_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir,  double hitsize);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_hitsize_set_api_delegate> efl_ui_flip_interaction_direction_hitsize_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_hitsize_set_api_delegate>(Module, "efl_ui_flip_interaction_direction_hitsize_set");

        private static void interaction_direction_hitsize_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir, double hitsize)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_direction_hitsize_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((Flip)wrapper).SetInteractionDirectionHitsize(dir, hitsize);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_flip_interaction_direction_hitsize_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir, hitsize);
            }
        }

        private static efl_ui_flip_interaction_direction_hitsize_set_delegate efl_ui_flip_interaction_direction_hitsize_set_static_delegate;

        
        private delegate double efl_ui_flip_interaction_direction_hitsize_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir);

        
        public delegate double efl_ui_flip_interaction_direction_hitsize_get_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_hitsize_get_api_delegate> efl_ui_flip_interaction_direction_hitsize_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_hitsize_get_api_delegate>(Module, "efl_ui_flip_interaction_direction_hitsize_get");

        private static double interaction_direction_hitsize_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_direction_hitsize_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    double _ret_var = default(double);
                try
                {
                    _ret_var = ((Flip)wrapper).GetInteractionDirectionHitsize(dir);
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
                return efl_ui_flip_interaction_direction_hitsize_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_flip_interaction_direction_hitsize_get_delegate efl_ui_flip_interaction_direction_hitsize_get_static_delegate;

        
        private delegate void efl_ui_flip_interaction_direction_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_ui_flip_interaction_direction_enabled_set_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_enabled_set_api_delegate> efl_ui_flip_interaction_direction_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_enabled_set_api_delegate>(Module, "efl_ui_flip_interaction_direction_enabled_set");

        private static void interaction_direction_enabled_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir, bool enabled)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_direction_enabled_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((Flip)wrapper).SetInteractionDirectionEnabled(dir, enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_flip_interaction_direction_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir, enabled);
            }
        }

        private static efl_ui_flip_interaction_direction_enabled_set_delegate efl_ui_flip_interaction_direction_enabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_flip_interaction_direction_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_flip_interaction_direction_enabled_get_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_enabled_get_api_delegate> efl_ui_flip_interaction_direction_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_interaction_direction_enabled_get_api_delegate>(Module, "efl_ui_flip_interaction_direction_enabled_get");

        private static bool interaction_direction_enabled_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir)
        {
            Eina.Log.Debug("function efl_ui_flip_interaction_direction_enabled_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).GetInteractionDirectionEnabled(dir);
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
                return efl_ui_flip_interaction_direction_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_flip_interaction_direction_enabled_get_delegate efl_ui_flip_interaction_direction_enabled_get_static_delegate;

        
        private delegate void efl_ui_flip_go_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.FlipMode mode);

        
        public delegate void efl_ui_flip_go_api_delegate(System.IntPtr obj,  Efl.Ui.FlipMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_go_api_delegate> efl_ui_flip_go_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_go_api_delegate>(Module, "efl_ui_flip_go");

        private static void go(System.IntPtr obj, System.IntPtr pd, Efl.Ui.FlipMode mode)
        {
            Eina.Log.Debug("function efl_ui_flip_go was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Flip)wrapper).Go(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_flip_go_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_flip_go_delegate efl_ui_flip_go_static_delegate;

        
        private delegate void efl_ui_flip_go_to_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool front,  Efl.Ui.FlipMode mode);

        
        public delegate void efl_ui_flip_go_to_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool front,  Efl.Ui.FlipMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_flip_go_to_api_delegate> efl_ui_flip_go_to_ptr = new Efl.Eo.FunctionWrapper<efl_ui_flip_go_to_api_delegate>(Module, "efl_ui_flip_go_to");

        private static void go_to(System.IntPtr obj, System.IntPtr pd, bool front, Efl.Ui.FlipMode mode)
        {
            Eina.Log.Debug("function efl_ui_flip_go_to was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((Flip)wrapper).GoTo(front, mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_flip_go_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), front, mode);
            }
        }

        private static efl_ui_flip_go_to_delegate efl_ui_flip_go_to_static_delegate;

        
        private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(Module, "efl_content_iterate");

        private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_iterate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((Flip)wrapper).ContentIterate();
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
                return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_iterate_delegate efl_content_iterate_static_delegate;

        
        private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_content_count_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(Module, "efl_content_count");

        private static int content_count(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_count was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Flip)wrapper).ContentCount();
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
                return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_count_delegate efl_content_count_static_delegate;

        
        private delegate void efl_pack_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert);

        
        public delegate void efl_pack_align_get_api_delegate(System.IntPtr obj,  out double align_horiz,  out double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate> efl_pack_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate>(Module, "efl_pack_align_get");

        private static void pack_align_get(System.IntPtr obj, System.IntPtr pd, out double align_horiz, out double align_vert)
        {
            Eina.Log.Debug("function efl_pack_align_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        align_horiz = default(double);        align_vert = default(double);                            
                try
                {
                    ((Flip)wrapper).GetPackAlign(out align_horiz, out align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_pack_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out align_horiz, out align_vert);
            }
        }

        private static efl_pack_align_get_delegate efl_pack_align_get_static_delegate;

        
        private delegate void efl_pack_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert);

        
        public delegate void efl_pack_align_set_api_delegate(System.IntPtr obj,  double align_horiz,  double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate> efl_pack_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate>(Module, "efl_pack_align_set");

        private static void pack_align_set(System.IntPtr obj, System.IntPtr pd, double align_horiz, double align_vert)
        {
            Eina.Log.Debug("function efl_pack_align_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((Flip)wrapper).SetPackAlign(align_horiz, align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_pack_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), align_horiz, align_vert);
            }
        }

        private static efl_pack_align_set_delegate efl_pack_align_set_static_delegate;

        
        private delegate void efl_pack_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        
        public delegate void efl_pack_padding_get_api_delegate(System.IntPtr obj,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate> efl_pack_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate>(Module, "efl_pack_padding_get");

        private static void pack_padding_get(System.IntPtr obj, System.IntPtr pd, out double pad_horiz, out double pad_vert, out bool scalable)
        {
            Eina.Log.Debug("function efl_pack_padding_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                pad_horiz = default(double);        pad_vert = default(double);        scalable = default(bool);                                    
                try
                {
                    ((Flip)wrapper).GetPackPadding(out pad_horiz, out pad_vert, out scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_pack_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out pad_horiz, out pad_vert, out scalable);
            }
        }

        private static efl_pack_padding_get_delegate efl_pack_padding_get_static_delegate;

        
        private delegate void efl_pack_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        
        public delegate void efl_pack_padding_set_api_delegate(System.IntPtr obj,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate> efl_pack_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate>(Module, "efl_pack_padding_set");

        private static void pack_padding_set(System.IntPtr obj, System.IntPtr pd, double pad_horiz, double pad_vert, bool scalable)
        {
            Eina.Log.Debug("function efl_pack_padding_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((Flip)wrapper).SetPackPadding(pad_horiz, pad_vert, scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_pack_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pad_horiz, pad_vert, scalable);
            }
        }

        private static efl_pack_padding_set_delegate efl_pack_padding_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(Module, "efl_pack_clear");

        private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_clear was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).ClearPack();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).UnpackAll();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).Unpack(subobj);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).Pack(subobj);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).PackBegin(subobj);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).PackEnd(subobj);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).PackBefore(subobj, existing);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).PackAfter(subobj, existing);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Flip)wrapper).PackAt(subobj, index);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Flip)wrapper).GetPackContent(index);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Flip)wrapper).GetPackIndex(subobj);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Flip)wrapper).PackUnpackAt(index);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Efl UI flip mode</summary>
public enum FlipMode
{
/// <summary>Rotate Y center axis flip mode</summary>
RotateYCenterAxis = 0,
/// <summary>Rotate X center axis flip mode</summary>
RotateXCenterAxis = 1,
/// <summary>Rotate XZ center axis flip mode</summary>
RotateXzCenterAxis = 2,
/// <summary>Rotate YZ center axis flip mode</summary>
RotateYzCenterAxis = 3,
/// <summary>Cube left flip mode</summary>
CubeLeft = 4,
/// <summary>Cube right flip mode</summary>
CubeRight = 5,
/// <summary>Cube up flip mode</summary>
CubeUp = 6,
/// <summary>Cube down flip mode</summary>
CubeDown = 7,
/// <summary>Page left flip mode</summary>
PageLeft = 8,
/// <summary>Page right flip mode</summary>
PageRight = 9,
/// <summary>Page up flip mode</summary>
PageUp = 10,
/// <summary>Page down flip mode</summary>
PageDown = 11,
/// <summary>Cross fade flip mode</summary>
CrossFade = 12,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Efl UI flip interaction</summary>
public enum FlipInteraction
{
/// <summary>No interaction</summary>
None = 0,
/// <summary>Rotate interaction</summary>
Rotate = 1,
/// <summary>Cube interaction</summary>
Cube = 2,
/// <summary>Page interaction</summary>
Page = 3,
}

}

}

