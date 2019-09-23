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

/// <summary>Efl widget scrollable content mixin
/// This can be used to provide scrollable contents and text for widgets. When a scrollable text or content is set, this mixin will create and manage an internal scroller object which will be the container of that text or content.
/// 
/// Only a single content or text can be set at any given time. Setting <see cref="Efl.Ui.IWidgetScrollableContent.ScrollableContent"/> will unset <see cref="Efl.Ui.IWidgetScrollableContent.ScrollableText"/> and vice versa.
/// (Since EFL 1.23)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.WidgetScrollableContentConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IWidgetScrollableContent : 
    Efl.Eo.IWrapper, IDisposable
{
        /// <summary>This is the content which will be placed in the internal scroller.
/// If a scrollable text string is set, this will return <c>NULL</c>.
/// (Since EFL 1.23)</summary>
/// <returns>The content object.</returns>
Efl.Canvas.Object GetScrollableContent();
    /// <summary>This is the content which will be placed in the internal scroller.
/// If a scrollable text string is set, this will return <c>NULL</c>.
/// (Since EFL 1.23)</summary>
/// <param name="content">The content object.</param>
/// <returns>True on success</returns>
bool SetScrollableContent(Efl.Canvas.Object content);
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
/// When reading, do not free the return value.
/// (Since EFL 1.23)</summary>
/// <returns>Text string to display on it.</returns>
System.String GetScrollableText();
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
/// When reading, do not free the return value.
/// (Since EFL 1.23)</summary>
/// <param name="text">Text string to display on it.</param>
void SetScrollableText(System.String text);
                        /// <summary>The optimal size for the widget based on scrollable content.
    /// (Since EFL 1.23)</summary>
    /// <value><see cref="Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs"/></value>
    event EventHandler<Efl.Ui.WidgetScrollableContentOptimalSizeCalcEventArgs> OptimalSizeCalcEvent;
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <value>The content object.</value>
    Efl.Canvas.Object ScrollableContent {
        get;
        set;
    }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <value>Text string to display on it.</value>
    System.String ScrollableText {
        get;
        set;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IWidgetScrollableContent.OptimalSizeCalcEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class WidgetScrollableContentOptimalSizeCalcEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>The optimal size for the widget based on scrollable content.</value>
    public Eina.Size2D arg { get; set; }
}
/// <summary>Efl widget scrollable content mixin
/// This can be used to provide scrollable contents and text for widgets. When a scrollable text or content is set, this mixin will create and manage an internal scroller object which will be the container of that text or content.
/// 
/// Only a single content or text can be set at any given time. Setting <see cref="Efl.Ui.IWidgetScrollableContent.ScrollableContent"/> will unset <see cref="Efl.Ui.IWidgetScrollableContent.ScrollableText"/> and vice versa.
/// (Since EFL 1.23)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class WidgetScrollableContentConcrete :
    Efl.Eo.EoWrapper
    , IWidgetScrollableContent
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WidgetScrollableContentConcrete))
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
    private WidgetScrollableContentConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_widget_scrollable_content_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IWidgetScrollableContent"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private WidgetScrollableContentConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
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
#pragma warning disable CS0628
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
    protected bool GetScrollableContentDidGroupCalc() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_did_group_calc_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <returns>The content object.</returns>
    public Efl.Canvas.Object GetScrollableContent() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is the content which will be placed in the internal scroller.
    /// If a scrollable text string is set, this will return <c>NULL</c>.
    /// (Since EFL 1.23)</summary>
    /// <param name="content">The content object.</param>
    /// <returns>True on success</returns>
    public bool SetScrollableContent(Efl.Canvas.Object content) {
                                 var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_content_set_ptr.Value.Delegate(this.NativeHandle,content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <returns>Text string to display on it.</returns>
    public System.String GetScrollableText() {
         var _ret_var = Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_text_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object. The text will use <see cref="Efl.TextFormatWrap.Mixed"/> wrapping, and it will be scrollable depending on its size relative to the object&apos;s geometry.
    /// When reading, do not free the return value.
    /// (Since EFL 1.23)</summary>
    /// <param name="text">Text string to display on it.</param>
    public void SetScrollableText(System.String text) {
                                 Efl.Ui.WidgetScrollableContentConcrete.NativeMethods.efl_ui_widget_scrollable_text_set_ptr.Value.Delegate(this.NativeHandle,text);
        Eina.Error.RaiseIfUnhandledException();
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
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WidgetScrollableContentConcrete.efl_ui_widget_scrollable_content_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_widget_scrollable_content_get_static_delegate == null)
            {
                efl_ui_widget_scrollable_content_get_static_delegate = new efl_ui_widget_scrollable_content_get_delegate(scrollable_content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollableContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_content_get_static_delegate) });
            }

            if (efl_ui_widget_scrollable_content_set_static_delegate == null)
            {
                efl_ui_widget_scrollable_content_set_static_delegate = new efl_ui_widget_scrollable_content_set_delegate(scrollable_content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollableContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_content_set_static_delegate) });
            }

            if (efl_ui_widget_scrollable_text_get_static_delegate == null)
            {
                efl_ui_widget_scrollable_text_get_static_delegate = new efl_ui_widget_scrollable_text_get_delegate(scrollable_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollableText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_text_get_static_delegate) });
            }

            if (efl_ui_widget_scrollable_text_set_static_delegate == null)
            {
                efl_ui_widget_scrollable_text_set_static_delegate = new efl_ui_widget_scrollable_text_set_delegate(scrollable_text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollableText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scrollable_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scrollable_text_set_static_delegate) });
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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.WidgetScrollableContentConcrete.efl_ui_widget_scrollable_content_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_scrollable_content_did_group_calc_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate> efl_ui_widget_scrollable_content_did_group_calc_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_did_group_calc_get_api_delegate>(Module, "efl_ui_widget_scrollable_content_did_group_calc_get");

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_widget_scrollable_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_widget_scrollable_content_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_get_api_delegate> efl_ui_widget_scrollable_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_get_api_delegate>(Module, "efl_ui_widget_scrollable_content_get");

        private static Efl.Canvas.Object scrollable_content_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scrollable_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).GetScrollableContent();
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
                return efl_ui_widget_scrollable_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scrollable_content_get_delegate efl_ui_widget_scrollable_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_scrollable_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object content);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_scrollable_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object content);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_set_api_delegate> efl_ui_widget_scrollable_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_content_set_api_delegate>(Module, "efl_ui_widget_scrollable_content_set");

        private static bool scrollable_content_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object content)
        {
            Eina.Log.Debug("function efl_ui_widget_scrollable_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).SetScrollableContent(content);
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
                return efl_ui_widget_scrollable_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), content);
            }
        }

        private static efl_ui_widget_scrollable_content_set_delegate efl_ui_widget_scrollable_content_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_scrollable_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_widget_scrollable_text_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_text_get_api_delegate> efl_ui_widget_scrollable_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_text_get_api_delegate>(Module, "efl_ui_widget_scrollable_text_get");

        private static System.String scrollable_text_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scrollable_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((IWidgetScrollableContent)ws.Target).GetScrollableText();
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
                return efl_ui_widget_scrollable_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scrollable_text_get_delegate efl_ui_widget_scrollable_text_get_static_delegate;

        
        private delegate void efl_ui_widget_scrollable_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate void efl_ui_widget_scrollable_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_text_set_api_delegate> efl_ui_widget_scrollable_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scrollable_text_set_api_delegate>(Module, "efl_ui_widget_scrollable_text_set");

        private static void scrollable_text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_ui_widget_scrollable_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IWidgetScrollableContent)ws.Target).SetScrollableText(text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_scrollable_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text);
            }
        }

        private static efl_ui_widget_scrollable_text_set_delegate efl_ui_widget_scrollable_text_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWidgetScrollableContentConcrete_ExtensionMethods {
    
    public static Efl.BindableProperty<Efl.Canvas.Object> ScrollableContent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IWidgetScrollableContent, T>magic = null) where T : Efl.Ui.IWidgetScrollableContent {
        return new Efl.BindableProperty<Efl.Canvas.Object>("scrollable_content", fac);
    }

    public static Efl.BindableProperty<System.String> ScrollableText<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IWidgetScrollableContent, T>magic = null) where T : Efl.Ui.IWidgetScrollableContent {
        return new Efl.BindableProperty<System.String>("scrollable_text", fac);
    }

}
#pragma warning restore CS1591
#endif
