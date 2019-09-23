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

/// <summary>A styled container widget which overlays a window&apos;s contents.
/// The Popup widget is a theme-capable container which can be used for various purposes. Regular contents can be set using the <see cref="Efl.IContent"/> interface, or basic scrollable contents can be set through the <see cref="Efl.Ui.IWidgetScrollableContent"/> mixin API. For contents which should be scrollable but require more fine-grained tuning, it may be necessary for users to set up and provide their own scroller object such as <see cref="Efl.Ui.Scroller"/>.
/// 
/// A Popup widget will create an overlay for the window contents. This overlay is an <see cref="Efl.Ui.PopupPartBackwall"/> object, which provides functionality for passing events through to the main window while the Popup is active as well as the ability to set background images for the Popup.
/// 
/// By default, a Popup is positioned by the user through the <see cref="Efl.Gfx.IEntity.Position"/> property. This behavior can be altered by using the <see cref="Efl.Ui.Popup.Align"/> and <see cref="Efl.Ui.Popup.Anchor"/> properties. Setting the <see cref="Efl.Gfx.IEntity.Position"/> property directly will unset both the <see cref="Efl.Ui.Popup.Align"/> and <see cref="Efl.Ui.Popup.Anchor"/> properties, and vice versa.
/// 
/// By default, a Popup will size itself based on the minimum size of its contents through the <see cref="Efl.Gfx.IHint"/> interface. A Popup will never size itself smaller than the minimum size of its contents, but by manually setting the <see cref="Efl.Gfx.IEntity.Size"/> property or the <see cref="Efl.Gfx.IHint.HintSizeMin"/> property, a larger size can be specified.
/// 
/// Users can set a given Popup widget to close automatically after a specified time using the <see cref="Efl.Ui.Popup.ClosingTimeout"/> property.
/// 
/// For a Popup with a more specialized purpose, see <see cref="Efl.Ui.AlertPopup"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Popup.NativeMethods]
[Efl.Eo.BindingEntity]
public class Popup : Efl.Ui.LayoutBase, Efl.IContent, Efl.Ui.IWidgetFocusManager, Efl.Ui.IWidgetScrollableContent, Efl.Ui.Focus.ILayer, Efl.Ui.Focus.IManager
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Popup))
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
        efl_ui_popup_class_get();
    /// <summary>Initializes a new instance of the <see cref="Popup"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Popup(Efl.Object parent
            , System.String style = null) : base(efl_ui_popup_class_get(), parent)
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
    protected Popup(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Popup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Popup(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Popup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Popup(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>This is called whenever the user clicks the backwall part of the Popup.</summary>
    public event EventHandler BackwallClickedEvent
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

                string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BackwallClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBackwallClickedEvent(EventArgs e)
    {
        var key = "_EFL_UI_POPUP_EVENT_BACKWALL_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>This is called when Popup times out.</summary>
    public event EventHandler TimeoutEvent
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

                string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event TimeoutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnTimeoutEvent(EventArgs e)
    {
        var key = "_EFL_UI_POPUP_EVENT_TIMEOUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContentContentChangedEventArgs"/></value>
    public event EventHandler<Efl.ContentContentChangedEventArgs> ContentChangedEvent
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
                        Efl.ContentContentChangedEventArgs args = new Efl.ContentContentChangedEventArgs();
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

                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentChangedEvent(Efl.ContentContentChangedEventArgs e)
    {
        var key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>The optimal size for the widget based on scrollable content.
    /// (Since EFL 1.23)</summary>
    /// <value><see cref="Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs"/></value>
    public event EventHandler<Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs> OptimalSizeCalcEvent
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
                        Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs args = new Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs();
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

                string key = "_EFL_UI_WIDGET_SCROLLABLE_CONTENT_EVENT_OPTIMAL_SIZE_CALC";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIDGET_SCROLLABLE_CONTENT_EVENT_OPTIMAL_SIZE_CALC";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event OptimalSizeCalcEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnOptimalSizeCalcEvent(Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs e)
    {
        var key = "_EFL_UI_WIDGET_SCROLLABLE_CONTENT_EVENT_OPTIMAL_SIZE_CALC";
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
    /// <summary>Redirect object has changed, the old manager is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerRedirectChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEventArgs> RedirectChangedEvent
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
                        Efl.Ui.Focus.ManagerRedirectChangedEventArgs args = new Efl.Ui.Focus.ManagerRedirectChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ManagerConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RedirectChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRedirectChangedEvent(Efl.Ui.Focus.ManagerRedirectChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>After this event, the manager object will calculate relations in the graph. Can be used to add / remove children in a lazy fashion.
    /// (Since EFL 1.22)</summary>
    public event EventHandler FlushPreEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event FlushPreEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFlushPreEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Cached relationship calculation results have been invalidated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler CoordsDirtyEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event CoordsDirtyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCoordsDirtyEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The manager_focus property has changed. The previously focused object is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs> ManagerFocusChangedEvent
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
                        Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs args = new Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ObjectConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ManagerFocusChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnManagerFocusChangedEvent(Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when this focus manager is frozen or thawed, even_info being <c>true</c> indicates that it is now frozen, <c>false</c> indicates that it is thawed.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs> DirtyLogicFreezeChangedEvent
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
                        Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs args = new Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs();
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DirtyLogicFreezeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDirtyLogicFreezeChangedEvent(Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
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
    /// <summary>A backwall behind the Popup.</summary>
    public Efl.Ui.PopupPartBackwall BackwallPart
    {
        get
        {
            return GetPart("backwall") as Efl.Ui.PopupPartBackwall;
        }
    }
    /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
    /// When set, this property will override any user-provided value for the widget&apos;s <see cref="Efl.Gfx.IEntity.Position"/> property.</summary>
    /// <returns>Alignment of the Popup relative to its anchor. The default is <see cref="Efl.Ui.PopupAlign.None"/>.</returns>
    public virtual Efl.Ui.PopupAlign GetAlign() {
         var _ret_var = Efl.Ui.Popup.NativeMethods.efl_ui_popup_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
    /// When set, this property will override any user-provided value for the widget&apos;s <see cref="Efl.Gfx.IEntity.Position"/> property.</summary>
    /// <param name="type">Alignment of the Popup relative to its anchor. The default is <see cref="Efl.Ui.PopupAlign.None"/>.</param>
    public virtual void SetAlign(Efl.Ui.PopupAlign type) {
                                 Efl.Ui.Popup.NativeMethods.efl_ui_popup_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
    /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
    /// <returns>If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</returns>
    public virtual double GetClosingTimeout() {
         var _ret_var = Efl.Ui.Popup.NativeMethods.efl_ui_popup_closing_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
    /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
    /// <param name="time">If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</param>
    public virtual void SetClosingTimeout(double time) {
                                 Efl.Ui.Popup.NativeMethods.efl_ui_popup_closing_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),time);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="Efl.Ui.Popup.Align"/> and <see cref="Efl.Ui.Popup.GetAlignPriority"/> properties.
    /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
    /// 
    /// If <see cref="Efl.Ui.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="Efl.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
    /// <returns>The object which Popup is following. By default this is <c>NULL</c>.</returns>
    public virtual Efl.Canvas.Object GetAnchor() {
         var _ret_var = Efl.Ui.Popup.NativeMethods.efl_ui_popup_anchor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="Efl.Ui.Popup.Align"/> and <see cref="Efl.Ui.Popup.GetAlignPriority"/> properties.
    /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
    /// 
    /// If <see cref="Efl.Ui.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="Efl.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
    /// <param name="anchor">The object which Popup is following. By default this is <c>NULL</c>.</param>
    public virtual void SetAnchor(Efl.Canvas.Object anchor) {
                                 Efl.Ui.Popup.NativeMethods.efl_ui_popup_anchor_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),anchor);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="Efl.Ui.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
    /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="Efl.Ui.PopupAlign.Center"/> is specified.</summary>
    /// <param name="first">First alignment. The default is <see cref="Efl.Ui.PopupAlign.Top"/>.</param>
    /// <param name="second">Second alignment. The default is <see cref="Efl.Ui.PopupAlign.Left"/>.</param>
    /// <param name="third">Third alignment. The default is <see cref="Efl.Ui.PopupAlign.Right"/>.</param>
    /// <param name="fourth">Fourth alignment. The default is <see cref="Efl.Ui.PopupAlign.Bottom"/>.</param>
    /// <param name="fifth">Fifth alignment. The default is <see cref="Efl.Ui.PopupAlign.Center"/>.</param>
    public virtual void GetAlignPriority(out Efl.Ui.PopupAlign first, out Efl.Ui.PopupAlign second, out Efl.Ui.PopupAlign third, out Efl.Ui.PopupAlign fourth, out Efl.Ui.PopupAlign fifth) {
                                                                                                                                 Efl.Ui.Popup.NativeMethods.efl_ui_popup_align_priority_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out first, out second, out third, out fourth, out fifth);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="Efl.Ui.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
    /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="Efl.Ui.PopupAlign.Center"/> is specified.</summary>
    /// <param name="first">First alignment. The default is <see cref="Efl.Ui.PopupAlign.Top"/>.</param>
    /// <param name="second">Second alignment. The default is <see cref="Efl.Ui.PopupAlign.Left"/>.</param>
    /// <param name="third">Third alignment. The default is <see cref="Efl.Ui.PopupAlign.Right"/>.</param>
    /// <param name="fourth">Fourth alignment. The default is <see cref="Efl.Ui.PopupAlign.Bottom"/>.</param>
    /// <param name="fifth">Fifth alignment. The default is <see cref="Efl.Ui.PopupAlign.Center"/>.</param>
    public virtual void SetAlignPriority(Efl.Ui.PopupAlign first, Efl.Ui.PopupAlign second, Efl.Ui.PopupAlign third, Efl.Ui.PopupAlign fourth, Efl.Ui.PopupAlign fifth) {
                                                                                                                                 Efl.Ui.Popup.NativeMethods.efl_ui_popup_align_priority_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),first, second, third, fourth, fifth);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <returns>The sub-object.</returns>
    public virtual Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    public virtual bool SetContent(Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    public virtual Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overridden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    protected virtual Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.WidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Widgets can call this function during their <see cref="Efl.Canvas.Group.CalculateGroup"/> implementation after the super call to determine whether the internal scroller has performed sizing calculations.
    /// The optimal_size,calc event will have been emitted during the super call if this method returns <c>true</c>.
    /// 
    /// In the case that this returns <c>true</c>, it&apos;s likely that the widget should be completing its internal sizing calculations from the <see cref="Efl.Ui.IWidgetScrollableContent.OptimalSizeCalcEvent"/> callback using
    /// 
    /// efl_canvas_group_calculate(efl_super(ev-&gt;object, EFL_UI_WIDGET_SCROLLABLE_CONTENT_MIXIN));
    /// 
    /// in order to skip the scrollable sizing calc.
    /// (Since EFL 1.23)</summary>
    /// <returns>Whether the internal scroller has done sizing calcs.</returns>
    protected virtual bool GetScrollableContentDidGroupCalc() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_did_group_calc_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <returns>The content object.</returns>
    public virtual Efl.Canvas.Object GetScrollableContent() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <param name="content">The content object.</param>
    /// <returns>True on success</returns>
    public virtual bool SetScrollableContent(Efl.Canvas.Object content) {
                                 var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetScrollableText() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetScrollableText(System.String text) {
                                 Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <returns><c>true</c> to set enable.</returns>
    protected virtual bool GetEnable() {
         var _ret_var = Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <param name="v"><c>true</c> to set enable.</param>
    protected virtual void SetEnable(bool v) {
                                 Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected virtual void GetBehaviour(out bool enable_on_visible, out bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out enable_on_visible, out cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected virtual void SetBehaviour(bool enable_on_visible, bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable_on_visible, cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    public virtual Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    public virtual void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new focus manager.</returns>
    public virtual Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The new focus manager.</param>
    public virtual void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>An iterator over the viewport border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Object to register as the root of this manager object.</returns>
    public virtual Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Object to register as the root of this manager object.</param>
    /// <returns><c>true</c> on success, <c>false</c> if it had already been set.</returns>
    public virtual bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Moves the focus in the given direction to the next regular widget.
    /// This call flushes all changes. This means all changes since last flush are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    public virtual Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a regular. Note that in a <see cref="Efl.Ui.Focus.IManager.Move"/> call logical nodes will not get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    public virtual Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Returns the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    public virtual Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Fetches the data from a registered node.
    /// Note: This function triggers a computation of all dirty nodes.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="child">The child object to inspect.</param>
    /// <returns>The list of relations starting from <c>child</c>.</returns>
    public virtual Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Returns the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move in the &quot;next&quot; direction.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    public virtual Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    public virtual void ResetHistory() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Removes the uppermost history element, and focuses the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    public virtual void PopHistoryStack() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as a result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    public virtual void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widgets in the set do not change and complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    public virtual void FreezeDirtyLogic() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    public virtual void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The align property specifies a Popup&apos;s current positioning relative to its anchor.
    /// When set, this property will override any user-provided value for the widget&apos;s <see cref="Efl.Gfx.IEntity.Position"/> property.</summary>
    /// <value>Alignment of the Popup relative to its anchor. The default is <see cref="Efl.Ui.PopupAlign.None"/>.</value>
    public Efl.Ui.PopupAlign Align {
        get { return GetAlign(); }
        set { SetAlign(value); }
    }
    /// <summary>The closing_timeout property is the time after which the Popup widget will be automatically deleted.
    /// The timer is initiated at the time when the popup is shown. If the value is changed prior to the timer expiring, the existing timer will be deleted. If the new value is greater than $0, a new timer will be created.</summary>
    /// <value>If greater than $0, the Popup will close automatically after the value in seconds. The default is to not automatically delete the Popup.</value>
    public double ClosingTimeout {
        get { return GetClosingTimeout(); }
        set { SetClosingTimeout(value); }
    }
    /// <summary>The anchor object is the reference object for positioning a Popup using the <see cref="Efl.Ui.Popup.Align"/> and <see cref="Efl.Ui.Popup.GetAlignPriority"/> properties.
    /// A Popup will recalculate its alignment relative to its anchor and change its position when: - the anchor object is moved (unless the anchor is a window) - the anchor object is resized - the Popup is resized - the parent window is resized
    /// 
    /// If <see cref="Efl.Ui.Popup.GetAnchor"/> returns <c>NULL</c>, the anchor is the parent window of the Popup. If the anchor object is set to <c>NULL</c>, the Popup will no longer recalculate its alignment or change its position under any circumstance. If the Popup is moved by using <see cref="Efl.Gfx.IEntity.SetPosition"/>, <c>anchor</c> is set <c>NULL</c>.</summary>
    /// <value>The object which Popup is following. By default this is <c>NULL</c>.</value>
    public Efl.Canvas.Object Anchor {
        get { return GetAnchor(); }
        set { SetAnchor(value); }
    }
    /// <summary>This is the priority in which alignments will be tested using the anchor object if the value of <see cref="Efl.Ui.Popup.Align"/> is determined to be invalid. If a given alignment would result in the popup being partially or fully outside the visible area of the window, it is deemed invalid, and the next alignment is tested until either the priority list is exhausted or a usable alignment is found.
    /// An alignment will also be deemed invalid if the popup occludes its anchor object, except if <see cref="Efl.Ui.PopupAlign.Center"/> is specified.</summary>
    /// <value>First alignment. The default is <see cref="Efl.Ui.PopupAlign.Top"/>.</value>
    public (Efl.Ui.PopupAlign, Efl.Ui.PopupAlign, Efl.Ui.PopupAlign, Efl.Ui.PopupAlign, Efl.Ui.PopupAlign) AlignPriority {
        get {
            Efl.Ui.PopupAlign _out_first = default(Efl.Ui.PopupAlign);
            Efl.Ui.PopupAlign _out_second = default(Efl.Ui.PopupAlign);
            Efl.Ui.PopupAlign _out_third = default(Efl.Ui.PopupAlign);
            Efl.Ui.PopupAlign _out_fourth = default(Efl.Ui.PopupAlign);
            Efl.Ui.PopupAlign _out_fifth = default(Efl.Ui.PopupAlign);
            GetAlignPriority(out _out_first,out _out_second,out _out_third,out _out_fourth,out _out_fifth);
            return (_out_first,_out_second,_out_third,_out_fourth,_out_fifth);
        }
        set { SetAlignPriority( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }
    /// <summary>Widgets can call this function during their <see cref="Efl.Canvas.Group.CalculateGroup"/> implementation after the super call to determine whether the internal scroller has performed sizing calculations.
    /// The optimal_size,calc event will have been emitted during the super call if this method returns <c>true</c>.
    /// 
    /// In the case that this returns <c>true</c>, it&apos;s likely that the widget should be completing its internal sizing calculations from the <see cref="Efl.Ui.IWidgetScrollableContent.OptimalSizeCalcEvent"/> callback using
    /// 
    /// efl_canvas_group_calculate(efl_super(ev-&gt;object, EFL_UI_WIDGET_SCROLLABLE_CONTENT_MIXIN));
    /// 
    /// in order to skip the scrollable sizing calc.
    /// (Since EFL 1.23)</summary>
    /// <value>Whether the internal scroller has done sizing calcs.</value>
    protected bool ScrollableContentDidGroupCalc {
        get { return GetScrollableContentDidGroupCalc(); }
    }
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <value>The content object.</value>
    public Efl.Canvas.Object ScrollableContent {
        get { return GetScrollableContent(); }
        set { SetScrollableContent(value); }
    }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <value>Text string to display on it.</value>
    public System.String ScrollableText {
        get { return GetScrollableText(); }
        set { SetScrollableText(value); }
    }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <value><c>true</c> to set enable.</value>
    protected bool Enable {
        get { return GetEnable(); }
        set { SetEnable(value); }
    }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <value><c>true</c> means layer will enable itself once the widget becomes visible</value>
    protected (bool, bool) Behaviour {
        get {
            bool _out_enable_on_visible = default(bool);
            bool _out_cycle = default(bool);
            GetBehaviour(out _out_enable_on_visible,out _out_cycle);
            return (_out_enable_on_visible,_out_cycle);
        }
        set { SetBehaviour( value.Item1,  value.Item2); }
    }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <value>Currently focused element.</value>
    public Efl.Ui.Focus.IObject ManagerFocus {
        get { return GetManagerFocus(); }
        set { SetManagerFocus(value); }
    }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <value>The new focus manager.</value>
    public Efl.Ui.Focus.IManager Redirect {
        get { return GetRedirect(); }
        set { SetRedirect(value); }
    }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>An iterator over the border objects.</value>
    public Eina.Iterator<Efl.Ui.Focus.IObject> BorderElements {
        get { return GetBorderElements(); }
    }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <value>Object to register as the root of this manager object.</value>
    public Efl.Ui.Focus.IObject Root {
        get { return GetRoot(); }
        set { SetRoot(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Popup.efl_ui_popup_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_popup_align_get_static_delegate == null)
            {
                efl_ui_popup_align_get_static_delegate = new efl_ui_popup_align_get_delegate(align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_get_static_delegate) });
            }

            if (efl_ui_popup_align_set_static_delegate == null)
            {
                efl_ui_popup_align_set_static_delegate = new efl_ui_popup_align_set_delegate(align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_set_static_delegate) });
            }

            if (efl_ui_popup_closing_timeout_get_static_delegate == null)
            {
                efl_ui_popup_closing_timeout_get_static_delegate = new efl_ui_popup_closing_timeout_get_delegate(closing_timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClosingTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_closing_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_closing_timeout_get_static_delegate) });
            }

            if (efl_ui_popup_closing_timeout_set_static_delegate == null)
            {
                efl_ui_popup_closing_timeout_set_static_delegate = new efl_ui_popup_closing_timeout_set_delegate(closing_timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetClosingTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_closing_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_closing_timeout_set_static_delegate) });
            }

            if (efl_ui_popup_anchor_get_static_delegate == null)
            {
                efl_ui_popup_anchor_get_static_delegate = new efl_ui_popup_anchor_get_delegate(anchor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnchor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_anchor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_anchor_get_static_delegate) });
            }

            if (efl_ui_popup_anchor_set_static_delegate == null)
            {
                efl_ui_popup_anchor_set_static_delegate = new efl_ui_popup_anchor_set_delegate(anchor_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnchor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_anchor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_anchor_set_static_delegate) });
            }

            if (efl_ui_popup_align_priority_get_static_delegate == null)
            {
                efl_ui_popup_align_priority_get_static_delegate = new efl_ui_popup_align_priority_get_delegate(align_priority_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlignPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_priority_get_static_delegate) });
            }

            if (efl_ui_popup_align_priority_set_static_delegate == null)
            {
                efl_ui_popup_align_priority_set_static_delegate = new efl_ui_popup_align_priority_set_delegate(align_priority_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlignPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_popup_align_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_popup_align_priority_set_static_delegate) });
            }

            if (efl_ui_widget_focus_manager_create_static_delegate == null)
            {
                efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusManagerCreate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate) });
            }

            if (efl_ui_widget_scrollable_content_did_group_calc_get_static_delegate == null)
            {
                efl_ui_widget_scrollable_content_did_group_calc_get_static_delegate = new efl_ui_widget_scrollable_content_did_group_calc_get_delegate(scrollable_content_did_group_calc_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollableContentDidGroupCalc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_content_did_group_calc_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_content_did_group_calc_get_static_delegate) });
            }

            if (efl_ui_focus_layer_enable_get_static_delegate == null)
            {
                efl_ui_focus_layer_enable_get_static_delegate = new efl_ui_focus_layer_enable_get_delegate(enable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEnable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_enable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_enable_get_static_delegate) });
            }

            if (efl_ui_focus_layer_enable_set_static_delegate == null)
            {
                efl_ui_focus_layer_enable_set_static_delegate = new efl_ui_focus_layer_enable_set_delegate(enable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEnable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_enable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_enable_set_static_delegate) });
            }

            if (efl_ui_focus_layer_behaviour_get_static_delegate == null)
            {
                efl_ui_focus_layer_behaviour_get_static_delegate = new efl_ui_focus_layer_behaviour_get_delegate(behaviour_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBehaviour") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_behaviour_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_behaviour_get_static_delegate) });
            }

            if (efl_ui_focus_layer_behaviour_set_static_delegate == null)
            {
                efl_ui_focus_layer_behaviour_set_static_delegate = new efl_ui_focus_layer_behaviour_set_delegate(behaviour_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBehaviour") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_behaviour_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_behaviour_set_static_delegate) });
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
            return Efl.Ui.Popup.efl_ui_popup_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.PopupAlign efl_ui_popup_align_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.PopupAlign efl_ui_popup_align_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_align_get_api_delegate> efl_ui_popup_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_align_get_api_delegate>(Module, "efl_ui_popup_align_get");

        private static Efl.Ui.PopupAlign align_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_popup_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.PopupAlign _ret_var = default(Efl.Ui.PopupAlign);
                try
                {
                    _ret_var = ((Popup)ws.Target).GetAlign();
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
                return efl_ui_popup_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_popup_align_get_delegate efl_ui_popup_align_get_static_delegate;

        
        private delegate void efl_ui_popup_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PopupAlign type);

        
        public delegate void efl_ui_popup_align_set_api_delegate(System.IntPtr obj,  Efl.Ui.PopupAlign type);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_align_set_api_delegate> efl_ui_popup_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_align_set_api_delegate>(Module, "efl_ui_popup_align_set");

        private static void align_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.PopupAlign type)
        {
            Eina.Log.Debug("function efl_ui_popup_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Popup)ws.Target).SetAlign(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_popup_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_ui_popup_align_set_delegate efl_ui_popup_align_set_static_delegate;

        
        private delegate double efl_ui_popup_closing_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_popup_closing_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_closing_timeout_get_api_delegate> efl_ui_popup_closing_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_closing_timeout_get_api_delegate>(Module, "efl_ui_popup_closing_timeout_get");

        private static double closing_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_popup_closing_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Popup)ws.Target).GetClosingTimeout();
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
                return efl_ui_popup_closing_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_popup_closing_timeout_get_delegate efl_ui_popup_closing_timeout_get_static_delegate;

        
        private delegate void efl_ui_popup_closing_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

        
        public delegate void efl_ui_popup_closing_timeout_set_api_delegate(System.IntPtr obj,  double time);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_closing_timeout_set_api_delegate> efl_ui_popup_closing_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_closing_timeout_set_api_delegate>(Module, "efl_ui_popup_closing_timeout_set");

        private static void closing_timeout_set(System.IntPtr obj, System.IntPtr pd, double time)
        {
            Eina.Log.Debug("function efl_ui_popup_closing_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Popup)ws.Target).SetClosingTimeout(time);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_popup_closing_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), time);
            }
        }

        private static efl_ui_popup_closing_timeout_set_delegate efl_ui_popup_closing_timeout_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_popup_anchor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_popup_anchor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_anchor_get_api_delegate> efl_ui_popup_anchor_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_anchor_get_api_delegate>(Module, "efl_ui_popup_anchor_get");

        private static Efl.Canvas.Object anchor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_popup_anchor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Popup)ws.Target).GetAnchor();
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
                return efl_ui_popup_anchor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_popup_anchor_get_delegate efl_ui_popup_anchor_get_static_delegate;

        
        private delegate void efl_ui_popup_anchor_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object anchor);

        
        public delegate void efl_ui_popup_anchor_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object anchor);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_anchor_set_api_delegate> efl_ui_popup_anchor_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_anchor_set_api_delegate>(Module, "efl_ui_popup_anchor_set");

        private static void anchor_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object anchor)
        {
            Eina.Log.Debug("function efl_ui_popup_anchor_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Popup)ws.Target).SetAnchor(anchor);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_popup_anchor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), anchor);
            }
        }

        private static efl_ui_popup_anchor_set_delegate efl_ui_popup_anchor_set_static_delegate;

        
        private delegate void efl_ui_popup_align_priority_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth);

        
        public delegate void efl_ui_popup_align_priority_get_api_delegate(System.IntPtr obj,  out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_align_priority_get_api_delegate> efl_ui_popup_align_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_align_priority_get_api_delegate>(Module, "efl_ui_popup_align_priority_get");

        private static void align_priority_get(System.IntPtr obj, System.IntPtr pd, out Efl.Ui.PopupAlign first, out Efl.Ui.PopupAlign second, out Efl.Ui.PopupAlign third, out Efl.Ui.PopupAlign fourth, out Efl.Ui.PopupAlign fifth)
        {
            Eina.Log.Debug("function efl_ui_popup_align_priority_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                first = default(Efl.Ui.PopupAlign);        second = default(Efl.Ui.PopupAlign);        third = default(Efl.Ui.PopupAlign);        fourth = default(Efl.Ui.PopupAlign);        fifth = default(Efl.Ui.PopupAlign);                                                    
                try
                {
                    ((Popup)ws.Target).GetAlignPriority(out first, out second, out third, out fourth, out fifth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_popup_align_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out first, out second, out third, out fourth, out fifth);
            }
        }

        private static efl_ui_popup_align_priority_get_delegate efl_ui_popup_align_priority_get_static_delegate;

        
        private delegate void efl_ui_popup_align_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth);

        
        public delegate void efl_ui_popup_align_priority_set_api_delegate(System.IntPtr obj,  Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth);

        public static Efl.Eo.FunctionWrapper<efl_ui_popup_align_priority_set_api_delegate> efl_ui_popup_align_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_popup_align_priority_set_api_delegate>(Module, "efl_ui_popup_align_priority_set");

        private static void align_priority_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.PopupAlign first, Efl.Ui.PopupAlign second, Efl.Ui.PopupAlign third, Efl.Ui.PopupAlign fourth, Efl.Ui.PopupAlign fifth)
        {
            Eina.Log.Debug("function efl_ui_popup_align_priority_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Popup)ws.Target).SetAlignPriority(first, second, third, fourth, fifth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_popup_align_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), first, second, third, fourth, fifth);
            }
        }

        private static efl_ui_popup_align_priority_set_delegate efl_ui_popup_align_priority_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate> efl_ui_widget_focus_manager_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate>(Module, "efl_ui_widget_focus_manager_create");

        private static Efl.Ui.Focus.IManager focus_manager_create(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject root)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_manager_create was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = ((Popup)ws.Target).FocusManagerCreate(root);
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
                return efl_ui_widget_focus_manager_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_ui_widget_focus_manager_create_delegate efl_ui_widget_focus_manager_create_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_scrollable_content_did_group_calc_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate> efl_ui_widget_scrollable_content_did_group_calc_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate>(Module, "efl_ui_widget_scrollable_content_did_group_calc_get");

        private static bool scrollable_content_did_group_calc_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scrollable_content_did_group_calc_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Popup)ws.Target).GetScrollableContentDidGroupCalc();
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
                return efl_ui_widget_scrollable_content_did_group_calc_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scrollable_content_did_group_calc_get_delegate efl_ui_widget_scrollable_content_did_group_calc_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_layer_enable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_layer_enable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate> efl_ui_focus_layer_enable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate>(Module, "efl_ui_focus_layer_enable_get");

        private static bool enable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_enable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Popup)ws.Target).GetEnable();
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
                return efl_ui_focus_layer_enable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_layer_enable_get_delegate efl_ui_focus_layer_enable_get_static_delegate;

        
        private delegate void efl_ui_focus_layer_enable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_ui_focus_layer_enable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate> efl_ui_focus_layer_enable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate>(Module, "efl_ui_focus_layer_enable_set");

        private static void enable_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_enable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Popup)ws.Target).SetEnable(v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_layer_enable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), v);
            }
        }

        private static efl_ui_focus_layer_enable_set_delegate efl_ui_focus_layer_enable_set_static_delegate;

        
        private delegate void efl_ui_focus_layer_behaviour_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate> efl_ui_focus_layer_behaviour_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate>(Module, "efl_ui_focus_layer_behaviour_get");

        private static void behaviour_get(System.IntPtr obj, System.IntPtr pd, out bool enable_on_visible, out bool cycle)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_behaviour_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        enable_on_visible = default(bool);        cycle = default(bool);                            
                try
                {
                    ((Popup)ws.Target).GetBehaviour(out enable_on_visible, out cycle);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_focus_layer_behaviour_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out enable_on_visible, out cycle);
            }
        }

        private static efl_ui_focus_layer_behaviour_get_delegate efl_ui_focus_layer_behaviour_get_static_delegate;

        
        private delegate void efl_ui_focus_layer_behaviour_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate> efl_ui_focus_layer_behaviour_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate>(Module, "efl_ui_focus_layer_behaviour_set");

        private static void behaviour_set(System.IntPtr obj, System.IntPtr pd, bool enable_on_visible, bool cycle)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_behaviour_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Popup)ws.Target).SetBehaviour(enable_on_visible, cycle);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_focus_layer_behaviour_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable_on_visible, cycle);
            }
        }

        private static efl_ui_focus_layer_behaviour_set_delegate efl_ui_focus_layer_behaviour_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiPopup_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.PopupAlign> Align<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Ui.PopupAlign>("align", fac);
    }

    public static Efl.BindableProperty<double> ClosingTimeout<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<double>("closing_timeout", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Object> Anchor<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Canvas.Object>("anchor", fac);
    }

    
    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

    
    public static Efl.BindableProperty<Efl.Canvas.Object> ScrollableContent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Canvas.Object>("scrollable_content", fac);
    }

    public static Efl.BindableProperty<System.String> ScrollableText<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<System.String>("scrollable_text", fac);
    }

    public static Efl.BindableProperty<bool> Enable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<bool>("enable", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> ManagerFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("manager_focus", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IManager> Redirect<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Ui.Focus.IManager>("redirect", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> Root<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T>magic = null) where T : Efl.Ui.Popup {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("root", fac);
    }

        public static Efl.BindablePart<Efl.Ui.PopupPartBackwall> BackwallPart<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Popup, T> x=null) where T : Efl.Ui.Popup
    {
        return new Efl.BindablePart<Efl.Ui.PopupPartBackwall>("backwall" ,fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>This is the alignment method for positioning Popup widgets.</summary>
[Efl.Eo.BindingEntity]
public enum PopupAlign
{
/// <summary>Popup not aligned.</summary>
None = 0,
/// <summary>Popup is aligned to the center of its anchor object.</summary>
Center = 1,
/// <summary>Popup&apos;s left edge is aligned to the left side of its anchor object.</summary>
Left = 2,
/// <summary>Popup&apos;s right edge is aligned to the right side of its anchor object.</summary>
Right = 3,
/// <summary>Popup&apos;s top is aligned to the top of its anchor object.</summary>
Top = 4,
/// <summary>Popup&apos;s bottom is aligned to the bottom of its anchor object.</summary>
Bottom = 5,
}

}

}

