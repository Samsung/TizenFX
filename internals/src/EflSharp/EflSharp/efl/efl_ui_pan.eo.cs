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

/// <summary>Pan widget class.
/// This widget positions its contents (set using <see cref="Efl.IContent.Content"/>) relative to the widget itself. This is particularly useful for large content which does not fit inside its container. In this case only a portion is shown.
/// 
/// The position of this &quot;window&quot; into the content can be changed using <see cref="Efl.Ui.Pan.PanPosition"/>. This widget does not provide means for a user to change the content&apos;s position (like scroll bars). This widget is meant to be used internally by other clases like <see cref="Efl.Ui.Scroll.Manager"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Pan.NativeMethods]
[Efl.Eo.BindingEntity]
public class Pan : Efl.Canvas.Group, Efl.IContent
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Pan))
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
        efl_ui_pan_class_get();
    /// <summary>Initializes a new instance of the <see cref="Pan"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Pan(Efl.Object parent= null
            ) : base(efl_ui_pan_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Pan(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pan"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Pan(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pan"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Pan(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>The content has changed.</summary>
    public event EventHandler PanContentChangedEvt
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

                string key = "_EFL_UI_PAN_EVENT_PAN_CONTENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PAN_EVENT_PAN_CONTENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PanContentChangedEvt.</summary>
    public void OnPanContentChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_PAN_EVENT_PAN_CONTENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>This widget&apos;s position or size has changed.</summary>
    public event EventHandler PanViewportChangedEvt
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

                string key = "_EFL_UI_PAN_EVENT_PAN_VIEWPORT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PAN_EVENT_PAN_VIEWPORT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PanViewportChangedEvt.</summary>
    public void OnPanViewportChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_PAN_EVENT_PAN_VIEWPORT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The content&apos;s position has changed.</summary>
    public event EventHandler PanPositionChangedEvt
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

                string key = "_EFL_UI_PAN_EVENT_PAN_POSITION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PAN_EVENT_PAN_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PanPositionChangedEvt.</summary>
    public void OnPanPositionChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_PAN_EVENT_PAN_POSITION_CHANGED";
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
    /// <value><see cref="Efl.IContentContentChangedEvt_Args"/></value>
    public event EventHandler<Efl.IContentContentChangedEvt_Args> ContentChangedEvt
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
                        Efl.IContentContentChangedEvt_Args args = new Efl.IContentContentChangedEvt_Args();
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
    /// <summary>Method to raise event ContentChangedEvt.</summary>
    public void OnContentChangedEvt(Efl.IContentContentChangedEvt_Args e)
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
    /// <summary>Position of the content inside the Pan widget.
    /// Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMin"/> makes the upper left corner of the content visible. Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMax"/> makes the lower right corner of the content visible. Values outside this range are valid and make the background show.</summary>
    /// <returns>Content position.</returns>
    virtual public Eina.Position2D GetPanPosition() {
         var _ret_var = Efl.Ui.Pan.NativeMethods.efl_ui_pan_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position of the content inside the Pan widget.
    /// Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMin"/> makes the upper left corner of the content visible. Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMax"/> makes the lower right corner of the content visible. Values outside this range are valid and make the background show.</summary>
    /// <param name="position">Content position.</param>
    virtual public void SetPanPosition(Eina.Position2D position) {
         Eina.Position2D.NativeStruct _in_position = position;
                        Efl.Ui.Pan.NativeMethods.efl_ui_pan_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_position);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Size of the content currently set through <see cref="Efl.IContent.Content"/>. This is a convenience proxy.</summary>
    /// <returns>The size of the content.</returns>
    virtual public Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.Pan.NativeMethods.efl_ui_pan_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position you can set to <see cref="Efl.Ui.Pan.PanPosition"/> so that the content&apos;s upper left corner is visible. Always (0, 0).</summary>
    /// <returns>Content&apos;s upper left corner position.</returns>
    virtual public Eina.Position2D GetPanPositionMin() {
         var _ret_var = Efl.Ui.Pan.NativeMethods.efl_ui_pan_position_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position you can set to <see cref="Efl.Ui.Pan.PanPosition"/> so that the content&apos;s lower right corner is visible. It depends both on the content&apos;s size and this widget&apos;s size.</summary>
    /// <returns>Content&apos;s lower right corner position.</returns>
    virtual public Eina.Position2D GetPanPositionMax() {
         var _ret_var = Efl.Ui.Pan.NativeMethods.efl_ui_pan_position_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <returns>The sub-object.</returns>
    virtual public Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    virtual public bool SetContent(Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    virtual public Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position of the content inside the Pan widget.
    /// Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMin"/> makes the upper left corner of the content visible. Setting the position to <see cref="Efl.Ui.Pan.GetPanPositionMax"/> makes the lower right corner of the content visible. Values outside this range are valid and make the background show.</summary>
    /// <value>Content position.</value>
    public Eina.Position2D PanPosition {
        get { return GetPanPosition(); }
        set { SetPanPosition(value); }
    }
    /// <summary>Size of the content currently set through <see cref="Efl.IContent.Content"/>. This is a convenience proxy.</summary>
    /// <value>The size of the content.</value>
    public Eina.Size2D ContentSize {
        get { return GetContentSize(); }
    }
    /// <summary>Position you can set to <see cref="Efl.Ui.Pan.PanPosition"/> so that the content&apos;s upper left corner is visible. Always (0, 0).</summary>
    /// <value>Content&apos;s upper left corner position.</value>
    public Eina.Position2D PanPositionMin {
        get { return GetPanPositionMin(); }
    }
    /// <summary>Position you can set to <see cref="Efl.Ui.Pan.PanPosition"/> so that the content&apos;s lower right corner is visible. It depends both on the content&apos;s size and this widget&apos;s size.</summary>
    /// <value>Content&apos;s lower right corner position.</value>
    public Eina.Position2D PanPositionMax {
        get { return GetPanPositionMax(); }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Pan.efl_ui_pan_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Group.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_pan_position_get_static_delegate == null)
            {
                efl_ui_pan_position_get_static_delegate = new efl_ui_pan_position_get_delegate(pan_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPanPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_pan_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_get_static_delegate) });
            }

            if (efl_ui_pan_position_set_static_delegate == null)
            {
                efl_ui_pan_position_set_static_delegate = new efl_ui_pan_position_set_delegate(pan_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPanPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_pan_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_set_static_delegate) });
            }

            if (efl_ui_pan_content_size_get_static_delegate == null)
            {
                efl_ui_pan_content_size_get_static_delegate = new efl_ui_pan_content_size_get_delegate(content_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_pan_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_content_size_get_static_delegate) });
            }

            if (efl_ui_pan_position_min_get_static_delegate == null)
            {
                efl_ui_pan_position_min_get_static_delegate = new efl_ui_pan_position_min_get_delegate(pan_position_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPanPositionMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_pan_position_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_min_get_static_delegate) });
            }

            if (efl_ui_pan_position_max_get_static_delegate == null)
            {
                efl_ui_pan_position_max_get_static_delegate = new efl_ui_pan_position_max_get_delegate(pan_position_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPanPositionMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_pan_position_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_pan_position_max_get_static_delegate) });
            }

            if (efl_content_get_static_delegate == null)
            {
                efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate) });
            }

            if (efl_content_set_static_delegate == null)
            {
                efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate) });
            }

            if (efl_content_unset_static_delegate == null)
            {
                efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnsetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Pan.efl_ui_pan_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Position2D.NativeStruct efl_ui_pan_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_pan_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_get_api_delegate> efl_ui_pan_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_get_api_delegate>(Module, "efl_ui_pan_position_get");

        private static Eina.Position2D.NativeStruct pan_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_pan_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Pan)ws.Target).GetPanPosition();
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
                return efl_ui_pan_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_pan_position_get_delegate efl_ui_pan_position_get_static_delegate;

        
        private delegate void efl_ui_pan_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct position);

        
        public delegate void efl_ui_pan_position_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct position);

        public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_set_api_delegate> efl_ui_pan_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_set_api_delegate>(Module, "efl_ui_pan_position_set");

        private static void pan_position_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct position)
        {
            Eina.Log.Debug("function efl_ui_pan_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_position = position;
                            
                try
                {
                    ((Pan)ws.Target).SetPanPosition(_in_position);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_pan_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), position);
            }
        }

        private static efl_ui_pan_position_set_delegate efl_ui_pan_position_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_pan_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_pan_content_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_pan_content_size_get_api_delegate> efl_ui_pan_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_content_size_get_api_delegate>(Module, "efl_ui_pan_content_size_get");

        private static Eina.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_pan_content_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Pan)ws.Target).GetContentSize();
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
                return efl_ui_pan_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_pan_content_size_get_delegate efl_ui_pan_content_size_get_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_pan_position_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_pan_position_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_min_get_api_delegate> efl_ui_pan_position_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_min_get_api_delegate>(Module, "efl_ui_pan_position_min_get");

        private static Eina.Position2D.NativeStruct pan_position_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_pan_position_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Pan)ws.Target).GetPanPositionMin();
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
                return efl_ui_pan_position_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_pan_position_min_get_delegate efl_ui_pan_position_min_get_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_pan_position_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_pan_position_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_pan_position_max_get_api_delegate> efl_ui_pan_position_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_pan_position_max_get_api_delegate>(Module, "efl_ui_pan_position_max_get");

        private static Eina.Position2D.NativeStruct pan_position_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_pan_position_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Pan)ws.Target).GetPanPositionMax();
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
                return efl_ui_pan_position_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_pan_position_max_get_delegate efl_ui_pan_position_max_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_content_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(Module, "efl_content_get");

        private static Efl.Gfx.IEntity content_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Pan)ws.Target).GetContent();
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
                return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_get_delegate efl_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity content);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity content);

        public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(Module, "efl_content_set");

        private static bool content_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity content)
        {
            Eina.Log.Debug("function efl_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pan)ws.Target).SetContent(content);
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
                return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), content);
            }
        }

        private static efl_content_set_delegate efl_content_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_content_unset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(Module, "efl_content_unset");

        private static Efl.Gfx.IEntity content_unset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_unset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Pan)ws.Target).UnsetContent();
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
                return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_unset_delegate efl_content_unset_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiPan_ExtensionMethods {
    public static Efl.BindableProperty<Eina.Position2D> PanPosition<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Pan, T>magic = null) where T : Efl.Ui.Pan {
        return new Efl.BindableProperty<Eina.Position2D>("pan_position", fac);
    }

    
    
    
    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Pan, T>magic = null) where T : Efl.Ui.Pan {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

}
#pragma warning restore CS1591
#endif
