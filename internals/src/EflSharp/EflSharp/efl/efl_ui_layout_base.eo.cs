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

/// <summary>EFL layout widget abstract.
/// A &quot;layout&quot; in the context of EFL is an object which interfaces with the internal layout engine. Layouts are created using the EDC language, and any widget which implements this abstract must have a corresponding theme group to load in order to graphically display anything.
/// 
/// Theme groups for EFL widgets must be versioned. This means having a &quot;version&quot; <c>data.item</c> key in the theme group for the widget. If the loaded theme group for a widget has version info which is lower than the currently-running EFL version, a warning will be printed to notify the user that new features may be available. If the loaded theme group for a widget has no version info, an error will be generated. If the loaded theme group for a widget has a version that is newer than the currently-running EFL version, a critical error will be printed to notify the user that the theme may not be compatible.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Ui.LayoutBase.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class LayoutBase : Efl.Ui.Widget, Efl.IContainer, Efl.Layout.ICalc, Efl.Layout.IGroup, Efl.Layout.ISignal, Efl.Ui.IFactoryBind
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LayoutBase))
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
        efl_ui_layout_base_class_get();

    /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public LayoutBase(Efl.Object parent
            , System.String style = null) : base(efl_ui_layout_base_class_get(), parent)
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
    protected LayoutBase(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LayoutBase(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class LayoutBaseRealized : LayoutBase
    {
        private LayoutBaseRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LayoutBase(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when theme changed</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler ThemeChangedEvent
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

                string key = "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ThemeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnThemeChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }


    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
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

    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
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

    /// <summary>The layout was recalculated.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler RecalcEvent
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

                string key = "_EFL_LAYOUT_EVENT_RECALC";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event RecalcEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRecalcEvent(EventArgs e)
    {
        var key = "_EFL_LAYOUT_EVENT_RECALC";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>A circular dependency between parts of the object was found.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Layout.CalcCircularDependencyEventArgs"/></value>
    public event EventHandler<Efl.Layout.CalcCircularDependencyEventArgs> CircularDependencyEvent
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
                        Efl.Layout.CalcCircularDependencyEventArgs args = new Efl.Layout.CalcCircularDependencyEventArgs();
                        args.arg = new Eina.Array<System.String>(evt.Info, false, false);
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

                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event CircularDependencyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCircularDependencyEvent(Efl.Layout.CalcCircularDependencyEventArgs e)
    {
        var key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.Handle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Set a multiplier for applying finger size to the layout.
    /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
    /// 
    /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="multiplier_x">Multiplier for X axis.</param>
    /// <param name="multiplier_y">Multiplier for Y axis.</param>
    public virtual void GetFingerSizeMultiplier(out uint multiplier_x, out uint multiplier_y) {
        Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_finger_size_multiplier_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out multiplier_x, out multiplier_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set a multiplier for applying finger size to the layout.
    /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
    /// 
    /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="multiplier_x">Multiplier for X axis.</param>
    /// <param name="multiplier_y">Multiplier for Y axis.</param>
    public virtual void SetFingerSizeMultiplier(uint multiplier_x, uint multiplier_y) {
        Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_finger_size_multiplier_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),multiplier_x, multiplier_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The theme of this widget, defines which edje group will be used.
    /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
    /// 
    /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="Efl.Ui.Layout"/> object.
    /// 
    /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="Efl.Ui.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
    /// 
    /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class of the group, eg. &quot;button&quot;.</param>
    /// <param name="group">The group, eg. &quot;base&quot;.<br/>The default value is <c>&quot;base&quot;</c>.</param>
    /// <param name="style">The style to use, eg &quot;default&quot;.<br/>The default value is <c>&quot;default&quot;</c>.</param>
    public virtual void GetTheme(out System.String klass, out System.String group, out System.String style) {
        Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_theme_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out klass, out group, out style);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The theme of this widget, defines which edje group will be used.
    /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
    /// 
    /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="Efl.Ui.Layout"/> object.
    /// 
    /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="Efl.Ui.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
    /// 
    /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">The class of the group, eg. &quot;button&quot;.</param>
    /// <param name="group">The group, eg. &quot;base&quot;.<br/>The default value is <c>&quot;base&quot;</c>.</param>
    /// <param name="style">The style to use, eg &quot;default&quot;.<br/>The default value is <c>&quot;default&quot;</c>.</param>
    /// <returns>Whether the theme was successfully applied or not, see the Efl.Ui.Theme.Apply_Error subset of <see cref="Eina.Error"/> for more information.</returns>
    public virtual Eina.Error SetTheme(System.String klass, System.String group, System.String style) {
        var _ret_var = Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_theme_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass, group, style);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This flag tells if this object will automatically mirror the rotation changes of the window to this object.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> to mirror orientation changes to the theme <c>false</c> otherwise</returns>
    public virtual bool GetAutomaticThemeRotation() {
        var _ret_var = Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_automatic_theme_rotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This flag tells if this object will automatically mirror the rotation changes of the window to this object.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="automatic"><c>true</c> to mirror orientation changes to the theme <c>false</c> otherwise</param>
    public virtual void SetAutomaticThemeRotation(bool automatic) {
        Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_automatic_theme_rotation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),automatic);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a new rotation value to this object.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="orientation">The new rotation angle, in degrees.</param>
    public virtual void ApplyThemeRotation(int orientation) {
        Efl.Ui.LayoutBase.NativeMethods.efl_ui_layout_theme_rotation_apply_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),orientation);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> IterateContent() {
        var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);

    }

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    public virtual int ContentCount() {
        var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether this object updates its size hints automatically.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Whether or not update the size hints.</returns>
    public virtual bool GetCalcAutoUpdateHints() {
        var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Enable or disable auto-update of size hints.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="update">Whether or not update the size hints.<br/>The default value is <c>false</c>.</param>
    public virtual void SetCalcAutoUpdateHints(bool update) {
        Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),update);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Calculates the minimum required size for a given layout object.
    /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
    /// 
    /// Note: At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
    /// 
    /// Warning: Be advised that invisible parts in the object will be taken into account in this calculation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
    /// <returns>The minimum required size.</returns>
    public virtual Eina.Size2D CalcSizeMin(Eina.Size2D restricted) {
        Eina.Size2D.NativeStruct _in_restricted = restricted;
var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_restricted);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
    /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
    /// 
    /// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The calculated region.</returns>
    public virtual Eina.Rect CalcPartsExtends() {
        var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Freezes the layout object.
    /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.ThawCalc"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The frozen state or 0 on error</returns>
    public virtual int FreezeCalc() {
        var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Thaws the layout object.
    /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
    /// 
    /// Note: If successive freezes were done, an equal number of thaws will be required.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
    public virtual int ThawCalc() {
        var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Forces a Size/Geometry calculation.
    /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected virtual void CalcForce() {
        Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_force_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The minimum size as set in EDC.</returns>
    public virtual Eina.Size2D GetGroupSizeMin() {
        var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The maximum size as set in EDC.</returns>
    public virtual Eina.Size2D GetGroupSizeMax() {
        var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
    /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
    /// 
    /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// 
    /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
    /// 
    /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The data field&apos;s key string</param>
    /// <returns>The data&apos;s value string.</returns>
    public virtual System.String GetGroupData(System.String key) {
        var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Returns <c>true</c> if the part exists in the EDC group.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="part">The part name to check.</param>
    /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
    public virtual bool GetPartExist(System.String part) {
        var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),part);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sends an (Edje) message to a given Edje object
    /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
    /// 
    /// Messages can go both ways, from code to theme, or theme to code.
    /// 
    /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="id">A identification number for the message to be sent</param>
    /// <param name="msg">The message&apos;s payload</param>
    public virtual void SendMessage(int id, Eina.Value msg) {
        Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id, msg);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
    /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
    /// 
    /// Signals can go both ways, from code to theme, or theme to code.
    /// 
    /// Though there are those common uses for the two strings, one is free to use them however they like.
    /// 
    /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[" set of <c>fnmatch</c>() operators can be used, both for emission and source.
    /// 
    /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
    /// 
    /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.ISignal.DelSignalCallback"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    public virtual bool AddSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
        GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes a signal-triggered callback from an object.
    /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    public virtual bool DelSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
        GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sends/emits an Edje signal to this layout.
    /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    public virtual void EmitSignal(System.String emission, System.String source) {
        Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_emit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Processes an object&apos;s messages and signals queue.
    /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
    /// 
    /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="recurse">Whether to process messages on children objects.</param>
    public virtual void ProcessSignal(bool recurse) {
        Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_process_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),recurse);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.BindProperty"/> at least once.</summary>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    public virtual Eina.Error BindFactory(System.String key, Efl.Ui.IFactory factory) {
        var _ret_var = Efl.Ui.FactoryBindConcrete.NativeMethods.efl_ui_factory_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, factory);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set a multiplier for applying finger size to the layout.
    /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
    /// 
    /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Multiplier for X axis.</value>
    public (uint, uint) FingerSizeMultiplier {
        get {
            uint _out_multiplier_x = default(uint);
            uint _out_multiplier_y = default(uint);
            GetFingerSizeMultiplier(out _out_multiplier_x,out _out_multiplier_y);
            return (_out_multiplier_x,_out_multiplier_y);
        }
        set { SetFingerSizeMultiplier( value.Item1,  value.Item2); }
    }

    /// <summary>The theme of this widget, defines which edje group will be used.
    /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
    /// 
    /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="Efl.Ui.Layout"/> object.
    /// 
    /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="Efl.Ui.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
    /// 
    /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The class of the group, eg. &quot;button&quot;.</value>
    public (System.String, System.String, System.String) Theme {
        get {
            System.String _out_klass = default(System.String);
            System.String _out_group = default(System.String);
            System.String _out_style = default(System.String);
            GetTheme(out _out_klass,out _out_group,out _out_style);
            return (_out_klass,_out_group,_out_style);
        }
        set { SetTheme( value.Item1,  value.Item2,  value.Item3); }
    }

    /// <summary>This flag tells if this object will automatically mirror the rotation changes of the window to this object.
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> to mirror orientation changes to the theme <c>false</c> otherwise</value>
    public bool AutomaticThemeRotation {
        get { return GetAutomaticThemeRotation(); }
        set { SetAutomaticThemeRotation(value); }
    }

    /// <summary>Whether this object updates its size hints automatically.
    /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
    /// 
    /// A layout recalculation can be triggered by <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Whether or not update the size hints.</value>
    public bool CalcAutoUpdateHints {
        get { return GetCalcAutoUpdateHints(); }
        set { SetCalcAutoUpdateHints(value); }
    }

    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The minimum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMin {
        get { return GetGroupSizeMin(); }
    }

    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The maximum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMax {
        get { return GetGroupSizeMax(); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutBase.efl_ui_layout_base_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_layout_finger_size_multiplier_get_static_delegate == null)
            {
                efl_ui_layout_finger_size_multiplier_get_static_delegate = new efl_ui_layout_finger_size_multiplier_get_delegate(finger_size_multiplier_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFingerSizeMultiplier") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_finger_size_multiplier_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_finger_size_multiplier_get_static_delegate) });
            }

            if (efl_ui_layout_finger_size_multiplier_set_static_delegate == null)
            {
                efl_ui_layout_finger_size_multiplier_set_static_delegate = new efl_ui_layout_finger_size_multiplier_set_delegate(finger_size_multiplier_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFingerSizeMultiplier") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_finger_size_multiplier_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_finger_size_multiplier_set_static_delegate) });
            }

            if (efl_ui_layout_theme_get_static_delegate == null)
            {
                efl_ui_layout_theme_get_static_delegate = new efl_ui_layout_theme_get_delegate(theme_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTheme") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_get_static_delegate) });
            }

            if (efl_ui_layout_theme_set_static_delegate == null)
            {
                efl_ui_layout_theme_set_static_delegate = new efl_ui_layout_theme_set_delegate(theme_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTheme") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_set_static_delegate) });
            }

            if (efl_ui_layout_automatic_theme_rotation_get_static_delegate == null)
            {
                efl_ui_layout_automatic_theme_rotation_get_static_delegate = new efl_ui_layout_automatic_theme_rotation_get_delegate(automatic_theme_rotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutomaticThemeRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_automatic_theme_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_automatic_theme_rotation_get_static_delegate) });
            }

            if (efl_ui_layout_automatic_theme_rotation_set_static_delegate == null)
            {
                efl_ui_layout_automatic_theme_rotation_set_static_delegate = new efl_ui_layout_automatic_theme_rotation_set_delegate(automatic_theme_rotation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutomaticThemeRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_automatic_theme_rotation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_automatic_theme_rotation_set_static_delegate) });
            }

            if (efl_ui_layout_theme_rotation_apply_static_delegate == null)
            {
                efl_ui_layout_theme_rotation_apply_static_delegate = new efl_ui_layout_theme_rotation_apply_delegate(theme_rotation_apply);
            }

            if (methods.FirstOrDefault(m => m.Name == "ApplyThemeRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_rotation_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_rotation_apply_static_delegate) });
            }

            if (efl_layout_calc_force_static_delegate == null)
            {
                efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcForce") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
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
            return Efl.Ui.LayoutBase.efl_ui_layout_base_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_layout_finger_size_multiplier_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint multiplier_x,  out uint multiplier_y);

        
        public delegate void efl_ui_layout_finger_size_multiplier_get_api_delegate(System.IntPtr obj,  out uint multiplier_x,  out uint multiplier_y);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_finger_size_multiplier_get_api_delegate> efl_ui_layout_finger_size_multiplier_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_finger_size_multiplier_get_api_delegate>(Module, "efl_ui_layout_finger_size_multiplier_get");

        private static void finger_size_multiplier_get(System.IntPtr obj, System.IntPtr pd, out uint multiplier_x, out uint multiplier_y)
        {
            Eina.Log.Debug("function efl_ui_layout_finger_size_multiplier_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                multiplier_x = default(uint);multiplier_y = default(uint);
                try
                {
                    ((LayoutBase)ws.Target).GetFingerSizeMultiplier(out multiplier_x, out multiplier_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_finger_size_multiplier_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out multiplier_x, out multiplier_y);
            }
        }

        private static efl_ui_layout_finger_size_multiplier_get_delegate efl_ui_layout_finger_size_multiplier_get_static_delegate;

        
        private delegate void efl_ui_layout_finger_size_multiplier_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint multiplier_x,  uint multiplier_y);

        
        public delegate void efl_ui_layout_finger_size_multiplier_set_api_delegate(System.IntPtr obj,  uint multiplier_x,  uint multiplier_y);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_finger_size_multiplier_set_api_delegate> efl_ui_layout_finger_size_multiplier_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_finger_size_multiplier_set_api_delegate>(Module, "efl_ui_layout_finger_size_multiplier_set");

        private static void finger_size_multiplier_set(System.IntPtr obj, System.IntPtr pd, uint multiplier_x, uint multiplier_y)
        {
            Eina.Log.Debug("function efl_ui_layout_finger_size_multiplier_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((LayoutBase)ws.Target).SetFingerSizeMultiplier(multiplier_x, multiplier_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_finger_size_multiplier_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), multiplier_x, multiplier_y);
            }
        }

        private static efl_ui_layout_finger_size_multiplier_set_delegate efl_ui_layout_finger_size_multiplier_set_static_delegate;

        
        private delegate void efl_ui_layout_theme_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String style);

        
        public delegate void efl_ui_layout_theme_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_theme_get_api_delegate> efl_ui_layout_theme_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_theme_get_api_delegate>(Module, "efl_ui_layout_theme_get");

        private static void theme_get(System.IntPtr obj, System.IntPtr pd, out System.String klass, out System.String group, out System.String style)
        {
            Eina.Log.Debug("function efl_ui_layout_theme_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _out_klass = default(System.String);
System.String _out_group = default(System.String);
System.String _out_style = default(System.String);

                try
                {
                    ((LayoutBase)ws.Target).GetTheme(out _out_klass, out _out_group, out _out_style);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        klass = _out_klass;
group = _out_group;
style = _out_style;
        
            }
            else
            {
                efl_ui_layout_theme_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out klass, out group, out style);
            }
        }

        private static efl_ui_layout_theme_get_delegate efl_ui_layout_theme_get_static_delegate;

        
        private delegate Eina.Error efl_ui_layout_theme_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        
        public delegate Eina.Error efl_ui_layout_theme_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_theme_set_api_delegate> efl_ui_layout_theme_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_theme_set_api_delegate>(Module, "efl_ui_layout_theme_set");

        private static Eina.Error theme_set(System.IntPtr obj, System.IntPtr pd, System.String klass, System.String group, System.String style)
        {
            Eina.Log.Debug("function efl_ui_layout_theme_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((LayoutBase)ws.Target).SetTheme(klass, group, style);
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
                return efl_ui_layout_theme_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), klass, group, style);
            }
        }

        private static efl_ui_layout_theme_set_delegate efl_ui_layout_theme_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_layout_automatic_theme_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_layout_automatic_theme_rotation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_automatic_theme_rotation_get_api_delegate> efl_ui_layout_automatic_theme_rotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_automatic_theme_rotation_get_api_delegate>(Module, "efl_ui_layout_automatic_theme_rotation_get");

        private static bool automatic_theme_rotation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_layout_automatic_theme_rotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((LayoutBase)ws.Target).GetAutomaticThemeRotation();
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
                return efl_ui_layout_automatic_theme_rotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_layout_automatic_theme_rotation_get_delegate efl_ui_layout_automatic_theme_rotation_get_static_delegate;

        
        private delegate void efl_ui_layout_automatic_theme_rotation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool automatic);

        
        public delegate void efl_ui_layout_automatic_theme_rotation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool automatic);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_automatic_theme_rotation_set_api_delegate> efl_ui_layout_automatic_theme_rotation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_automatic_theme_rotation_set_api_delegate>(Module, "efl_ui_layout_automatic_theme_rotation_set");

        private static void automatic_theme_rotation_set(System.IntPtr obj, System.IntPtr pd, bool automatic)
        {
            Eina.Log.Debug("function efl_ui_layout_automatic_theme_rotation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((LayoutBase)ws.Target).SetAutomaticThemeRotation(automatic);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_automatic_theme_rotation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), automatic);
            }
        }

        private static efl_ui_layout_automatic_theme_rotation_set_delegate efl_ui_layout_automatic_theme_rotation_set_static_delegate;

        
        private delegate void efl_ui_layout_theme_rotation_apply_delegate(System.IntPtr obj, System.IntPtr pd,  int orientation);

        
        public delegate void efl_ui_layout_theme_rotation_apply_api_delegate(System.IntPtr obj,  int orientation);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_theme_rotation_apply_api_delegate> efl_ui_layout_theme_rotation_apply_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_theme_rotation_apply_api_delegate>(Module, "efl_ui_layout_theme_rotation_apply");

        private static void theme_rotation_apply(System.IntPtr obj, System.IntPtr pd, int orientation)
        {
            Eina.Log.Debug("function efl_ui_layout_theme_rotation_apply was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((LayoutBase)ws.Target).ApplyThemeRotation(orientation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_layout_theme_rotation_apply_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), orientation);
            }
        }

        private static efl_ui_layout_theme_rotation_apply_delegate efl_ui_layout_theme_rotation_apply_static_delegate;

        
        private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

        private static void calc_force(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_force was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((LayoutBase)ws.Target).CalcForce();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_layout_calc_force_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiLayoutBase_ExtensionMethods {
    public static Efl.BindableProperty<bool> AutomaticThemeRotation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.LayoutBase, T>magic = null) where T : Efl.Ui.LayoutBase {
        return new Efl.BindableProperty<bool>("automatic_theme_rotation", fac);
    }

    public static Efl.BindableProperty<bool> CalcAutoUpdateHints<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.LayoutBase, T>magic = null) where T : Efl.Ui.LayoutBase {
        return new Efl.BindableProperty<bool>("calc_auto_update_hints", fac);
    }

}
#pragma warning restore CS1591
#endif
