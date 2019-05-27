#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary panes class</summary>
[Efl.Ui.Panes.NativeMethods]
public class Panes : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IClickable,Efl.Ui.IDirection
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Panes))
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
        efl_ui_panes_class_get();
    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Panes(Efl.Object parent
            , System.String style = null) : base(efl_ui_panes_class_get(), typeof(Panes), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Panes(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Panes(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Called when panes got pressed</summary>
    public event EventHandler PressEvt
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

                string key = "_ELM_PANES_EVENT_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_ELM_PANES_EVENT_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressEvt.</summary>
    public void OnPressEvt(EventArgs e)
    {
        var key = "_ELM_PANES_EVENT_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when panes are no longer pressed</summary>
    public event EventHandler UnpressEvt
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

                string key = "_ELM_PANES_EVENT_UNPRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_ELM_PANES_EVENT_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressEvt.</summary>
    public void OnUnpressEvt(EventArgs e)
    {
        var key = "_ELM_PANES_EVENT_UNPRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object is clicked</summary>
    public event EventHandler ClickedEvt
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

                string key = "_EFL_UI_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a double click</summary>
    public event EventHandler ClickedDoubleEvt
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

                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedDoubleEvt.</summary>
    public void OnClickedDoubleEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a triple click</summary>
    public event EventHandler ClickedTripleEvt
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

                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedTripleEvt.</summary>
    public void OnClickedTripleEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a right click</summary>
    public event EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> ClickedRightEvt
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
                                                Efl.Ui.IClickableClickedRightEvt_Args args = new Efl.Ui.IClickableClickedRightEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedRightEvt.</summary>
    public void OnClickedRightEvt(Efl.Ui.IClickableClickedRightEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object is pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
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
                                                Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object is no longer pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
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
                                                Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object receives a long press</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
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
                                                Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object receives repeated presses/clicks</summary>
    public event EventHandler RepeatedEvt
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

                string key = "_EFL_UI_EVENT_REPEATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_REPEATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event RepeatedEvt.</summary>
    public void OnRepeatedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_REPEATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The second half of the panes widget (right or bottom)</summary>
    public Efl.Ui.PanesPart Second
    {
        get
        {
            return GetPart("second") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>The first half of the panes widget (left or top)</summary>
    public Efl.Ui.PanesPart First
    {
        get
        {
            return GetPart("first") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <returns>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</returns>
    virtual public double GetSplitRatio() {
         var _ret_var = Efl.Ui.Panes.NativeMethods.efl_ui_panes_split_ratio_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <param name="ratio">Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</param>
    virtual public void SetSplitRatio(double ratio) {
                                 Efl.Ui.Panes.NativeMethods.efl_ui_panes_split_ratio_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),ratio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <returns>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</returns>
    virtual public bool GetFixed() {
         var _ret_var = Efl.Ui.Panes.NativeMethods.efl_ui_panes_fixed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <param name="kw_fixed">Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</param>
    virtual public void SetFixed(bool kw_fixed) {
                                 Efl.Ui.Panes.NativeMethods.efl_ui_panes_fixed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),kw_fixed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    virtual public Efl.Ui.Dir GetDirection() {
         var _ret_var = Efl.Ui.IDirectionConcrete.NativeMethods.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    virtual public void SetDirection(Efl.Ui.Dir dir) {
                                 Efl.Ui.IDirectionConcrete.NativeMethods.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the split ratio between panes widget first and second parts.
/// By default it&apos;s homogeneous, i.e., both sides have the same size.
/// 
/// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
/// 
/// If displayed vertically, first content is displayed at top, and second content at bottom.
/// 
/// Note: This ratio will change when user drags the panes bar.</summary>
/// <value>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</value>
    public double SplitRatio {
        get { return GetSplitRatio(); }
        set { SetSplitRatio(value); }
    }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
/// By default panes&apos; contents are resizable by user interaction.</summary>
/// <value>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</value>
    public bool Fixed {
        get { return GetFixed(); }
        set { SetFixed(value); }
    }
    /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
    public Efl.Ui.Dir Direction {
        get { return GetDirection(); }
        set { SetDirection(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Panes.efl_ui_panes_class_get();
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

            if (efl_ui_panes_split_ratio_get_static_delegate == null)
            {
                efl_ui_panes_split_ratio_get_static_delegate = new efl_ui_panes_split_ratio_get_delegate(split_ratio_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSplitRatio") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_split_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_get_static_delegate) });
            }

            if (efl_ui_panes_split_ratio_set_static_delegate == null)
            {
                efl_ui_panes_split_ratio_set_static_delegate = new efl_ui_panes_split_ratio_set_delegate(split_ratio_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSplitRatio") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_split_ratio_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_set_static_delegate) });
            }

            if (efl_ui_panes_fixed_get_static_delegate == null)
            {
                efl_ui_panes_fixed_get_static_delegate = new efl_ui_panes_fixed_get_delegate(fixed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFixed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_fixed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_get_static_delegate) });
            }

            if (efl_ui_panes_fixed_set_static_delegate == null)
            {
                efl_ui_panes_fixed_set_static_delegate = new efl_ui_panes_fixed_set_delegate(fixed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFixed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_fixed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_set_static_delegate) });
            }

            if (efl_ui_direction_get_static_delegate == null)
            {
                efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate) });
            }

            if (efl_ui_direction_set_static_delegate == null)
            {
                efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Panes.efl_ui_panes_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate double efl_ui_panes_split_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_panes_split_ratio_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate> efl_ui_panes_split_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate>(Module, "efl_ui_panes_split_ratio_get");

        private static double split_ratio_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panes_split_ratio_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Panes)wrapper).GetSplitRatio();
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
                return efl_ui_panes_split_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panes_split_ratio_get_delegate efl_ui_panes_split_ratio_get_static_delegate;

        
        private delegate void efl_ui_panes_split_ratio_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ratio);

        
        public delegate void efl_ui_panes_split_ratio_set_api_delegate(System.IntPtr obj,  double ratio);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate> efl_ui_panes_split_ratio_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate>(Module, "efl_ui_panes_split_ratio_set");

        private static void split_ratio_set(System.IntPtr obj, System.IntPtr pd, double ratio)
        {
            Eina.Log.Debug("function efl_ui_panes_split_ratio_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Panes)wrapper).SetSplitRatio(ratio);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panes_split_ratio_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ratio);
            }
        }

        private static efl_ui_panes_split_ratio_set_delegate efl_ui_panes_split_ratio_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_panes_fixed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_panes_fixed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate> efl_ui_panes_fixed_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate>(Module, "efl_ui_panes_fixed_get");

        private static bool fixed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panes_fixed_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Panes)wrapper).GetFixed();
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
                return efl_ui_panes_fixed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panes_fixed_get_delegate efl_ui_panes_fixed_get_static_delegate;

        
        private delegate void efl_ui_panes_fixed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool kw_fixed);

        
        public delegate void efl_ui_panes_fixed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool kw_fixed);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate> efl_ui_panes_fixed_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate>(Module, "efl_ui_panes_fixed_set");

        private static void fixed_set(System.IntPtr obj, System.IntPtr pd, bool kw_fixed)
        {
            Eina.Log.Debug("function efl_ui_panes_fixed_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Panes)wrapper).SetFixed(kw_fixed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panes_fixed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_fixed);
            }
        }

        private static efl_ui_panes_fixed_set_delegate efl_ui_panes_fixed_set_static_delegate;

        
        private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(Module, "efl_ui_direction_get");

        private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_direction_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
                try
                {
                    _ret_var = ((Panes)wrapper).GetDirection();
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
                return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;

        
        private delegate void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir);

        
        public delegate void efl_ui_direction_set_api_delegate(System.IntPtr obj,  Efl.Ui.Dir dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(Module, "efl_ui_direction_set");

        private static void direction_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Dir dir)
        {
            Eina.Log.Debug("function efl_ui_direction_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Panes)wrapper).SetDirection(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

