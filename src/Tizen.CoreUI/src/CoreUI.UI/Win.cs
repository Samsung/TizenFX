/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.Win.FullscreenChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class WinFullscreenChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when window is set to or from fullscreen</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.Win.MinimizedChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class WinMinimizedChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when window is set to or from minimized</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.Win.MaximizedChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class WinMaximizedChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when window is set to or from maximized</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.Win.WinRotationChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class WinWinRotationChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when window rotation is changed, sends current rotation in degrees</value>
        /// <since_tizen> 6 </since_tizen>
        public int Arg { get; set; }
    }

    /// <summary>CoreUI UI window class.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Win.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Win : CoreUI.UI.Widget, CoreUI.IContent, CoreUI.IScreen, CoreUI.IText, CoreUI.Canvas.IScene, CoreUI.Input.IState
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Win))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_win_class_get();

        /// <summary>Initializes a new instance of the <see cref="Win"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="winName">The window name. See <see cref="CoreUI.UI.Win.SetWinName" /></param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Win(CoreUI.Object parent, System.String winName = null, System.String style = null) : base(efl_ui_win_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(winName))
            {
                SetWinName(CoreUI.Wrapper.Globals.GetParamHelper(winName));
            }

            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Win(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Win"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Win(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Win"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Win(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when the window receives a delete request</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler DeleteRequest
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIN_EVENT_DELETE_REQUEST";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_DELETE_REQUEST";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event DeleteRequest.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnDeleteRequest()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_DELETE_REQUEST", IntPtr.Zero, null);
        }

        /// <summary>Called when window is set to or from fullscreen</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.WinFullscreenChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.WinFullscreenChangedEventArgs> FullscreenChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.WinFullscreenChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event FullscreenChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFullscreenChanged(CoreUI.UI.WinFullscreenChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when window is set to or from minimized</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.WinMinimizedChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.WinMinimizedChangedEventArgs> MinimizedChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.WinMinimizedChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_UI_WIN_EVENT_MINIMIZED_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_MINIMIZED_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event MinimizedChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMinimizedChanged(CoreUI.UI.WinMinimizedChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_MINIMIZED_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when window is set to or from maximized</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.WinMaximizedChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.WinMaximizedChangedEventArgs> MaximizedChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.WinMaximizedChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event MaximizedChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMaximizedChanged(CoreUI.UI.WinMaximizedChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when window rotation is changed, sends current rotation in degrees</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.WinWinRotationChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.WinWinRotationChangedEventArgs> WinRotationChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.WinWinRotationChangedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event WinRotationChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnWinRotationChanged(CoreUI.UI.WinWinRotationChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when theme is changed</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ThemeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIN_EVENT_THEME_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_THEME_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ThemeChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnThemeChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_THEME_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Called when the window is not going be displayed for some time</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Pause
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIN_EVENT_PAUSE";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_PAUSE";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Pause.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPause()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_PAUSE", IntPtr.Zero, null);
        }

        /// <summary>Called before a window is rendered after a pause event</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Resume
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIN_EVENT_RESUME";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIN_EVENT_RESUME";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Resume.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnResume()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIN_EVENT_RESUME", IntPtr.Zero, null);
        }


        /// <summary>Sent after the content is set or unset using the current content object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContentContentChangedEventArgs"/></value>
        public event EventHandler<CoreUI.ContentContentChangedEventArgs> ContentChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContentContentChangedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentChanged(CoreUI.ContentContentChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTENT_EVENT_CONTENT_CHANGED", info, null);
        }

        /// <summary>Called when scene got focus</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SceneFocusIn
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SceneFocusIn.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSceneFocusIn()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN", IntPtr.Zero, null);
        }

        /// <summary>Called when scene lost focus</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SceneFocusOut
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SceneFocusOut.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSceneFocusOut()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT", IntPtr.Zero, null);
        }

        /// <summary>Called when object got focus</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.SceneObjectFocusInEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.SceneObjectFocusInEventArgs> ObjectFocusIn
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.SceneObjectFocusInEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ObjectFocusIn.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnObjectFocusIn(CoreUI.Canvas.SceneObjectFocusInEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN", info, null);
        }

        /// <summary>Called when object lost focus</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.SceneObjectFocusOutEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.SceneObjectFocusOutEventArgs> ObjectFocusOut
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.SceneObjectFocusOutEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ObjectFocusOut.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnObjectFocusOut(CoreUI.Canvas.SceneObjectFocusOutEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT", info, null);
        }

        /// <summary>Called when pre render happens</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler RenderPre
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event RenderPre.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnRenderPre()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE", IntPtr.Zero, null);
        }

        /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
        /// 
        /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.</summary>
        /// <returns>The type, one of <see cref="CoreUI.UI.WinIndicatorMode"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.WinIndicatorMode GetIndicatorMode() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_indicator_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
        /// 
        /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.</summary>
        /// <param name="type">The type, one of <see cref="CoreUI.UI.WinIndicatorMode"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetIndicatorMode(CoreUI.UI.WinIndicatorMode type) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_indicator_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), type);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Enable quitting the main loop when this window is closed.
        /// 
        /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.</summary>
        /// <returns>The exit code to use when exiting</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Value GetExitOnClose() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_exit_on_close_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Enable quitting the main loop when this window is closed.
        /// 
        /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.</summary>
        /// <param name="exit_code">The exit code to use when exiting</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetExitOnClose(CoreUI.DataTypes.Value exit_code) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_exit_on_close_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), exit_code);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A window object&apos;s icon.
        /// 
        /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> or <see cref="CoreUI.UI.Image"/> are allowed.</summary>
        /// <returns>The Evas image object to use for an icon.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetIconObject() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_icon_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A window object&apos;s icon.
        /// 
        /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> or <see cref="CoreUI.UI.Image"/> are allowed.</summary>
        /// <param name="icon">The image object to use for an icon.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetIconObject(CoreUI.Canvas.Object icon) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_icon_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), icon);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The minimized state of a window.</summary>
        /// <returns>If <c>true</c>, the window is minimized.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetMinimized() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_minimized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The minimized state of a window.</summary>
        /// <param name="state">If <c>true</c>, the window is minimized.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMinimized(bool state) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_minimized_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), state);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The maximized state of a window.</summary>
        /// <returns>If <c>true</c>, the window is maximized.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetMaximized() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_maximized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The maximized state of a window.</summary>
        /// <param name="maximized">If <c>true</c>, the window is maximized.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMaximized(bool maximized) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_maximized_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), maximized);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The fullscreen state of a window.</summary>
        /// <returns>If <c>true</c>, the window is fullscreen.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFullscreen() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_fullscreen_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The fullscreen state of a window.</summary>
        /// <param name="fullscreen">If <c>true</c>, the window is fullscreen.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFullscreen(bool fullscreen) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_fullscreen_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), fullscreen);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The window name.
        /// 
        /// The meaning of name depends on the underlying windowing system.
        /// 
        /// The window name is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
        /// 
        /// <b>NOTE: </b>Once set, it cannot be modified afterwards.</summary>
        /// <returns>Window name</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetWinName() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The window name.
        /// 
        /// The meaning of name depends on the underlying windowing system.
        /// 
        /// The window name is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
        /// 
        /// <b>NOTE: </b>Once set, it cannot be modified afterwards.</summary>
        /// <param name="name">Window name</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetWinName(System.String name) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The alpha channel state of a window.
        /// 
        /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
        /// 
        /// <b>NOTE: </b>Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.</summary>
        /// <returns><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAlpha() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The alpha channel state of a window.
        /// 
        /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
        /// 
        /// <b>NOTE: </b>Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.</summary>
        /// <param name="alpha"><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAlpha(bool alpha) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), alpha);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Enable quitting the main loop when all windows are closed.
        /// 
        /// When set, the main loop will quit with the passed exit code once all windows have been closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnClose"/> which exits when a given window is closed.</summary>
        /// <returns>The exit code to use when exiting.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.DataTypes.Value GetExitOnAllWindowsClosed() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_exit_on_all_windows_closed_get_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Enable quitting the main loop when all windows are closed.
        /// 
        /// When set, the main loop will quit with the passed exit code once all windows have been closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnClose"/> which exits when a given window is closed.</summary>
        /// <param name="exit_code">The exit code to use when exiting.</param>
        /// <since_tizen> 6 </since_tizen>
        public static void SetExitOnAllWindowsClosed(CoreUI.DataTypes.Value exit_code) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_exit_on_all_windows_closed_set_ptr.Value.Delegate(exit_code);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Base size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.
        /// 
        /// See also <see cref="CoreUI.UI.Win.HintStep"/>.</summary>
        /// <returns>Base size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintBase() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_hint_base_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Base size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.
        /// 
        /// See also <see cref="CoreUI.UI.Win.HintStep"/>.</summary>
        /// <param name="sz">Base size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintBase(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.UI.Win.NativeMethods.efl_ui_win_hint_base_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Step size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Set this to for an object to scale up by steps and not continuously.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.</summary>
        /// <returns>Step size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintStep() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_hint_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Step size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Set this to for an object to scale up by steps and not continuously.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.</summary>
        /// <param name="sz">Step size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintStep(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.UI.Win.NativeMethods.efl_ui_win_hint_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether focus highlight is enabled or not on this window, regardless of the global setting.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <returns>The enabled value for the highlight.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFocusHighlightEnabled() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether focus highlight is enabled or not on this window, regardless of the global setting.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <param name="enabled">The enabled value for the highlight.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFocusHighlightEnabled(bool enabled) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enabled);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the widget focus highlight style.
        /// 
        /// If <c>style</c> is <c>null</c>, the default will be used.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <returns>The name of the focus highlight style.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetFocusHighlightStyle() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the widget focus highlight style.
        /// 
        /// If <c>style</c> is <c>null</c>, the default will be used.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <param name="style">The name of the focus highlight style.</param>
        /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetFocusHighlightStyle(System.String style) {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), style);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether focus highlight should animate or not.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>.</summary>
        /// <returns>The enabled value for the highlight animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFocusHighlightAnimate() {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_animate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether focus highlight should animate or not.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>.</summary>
        /// <param name="animate">The enabled value for the highlight animation.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFocusHighlightAnimate(bool animate) {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_focus_highlight_animate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), animate);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Activate a window object.
        /// 
        /// This function sends a request to the Window Manager to activate the window pointed by <c>obj</c>. If honored by the WM, the window will receive the keyboard focus.
        /// 
        /// <b>NOTE: </b>This is just a request that a Window Manager may ignore, so calling this function does not ensure in any way that the window will be the active one afterwards.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Activate() {
            CoreUI.UI.Win.NativeMethods.efl_ui_win_activate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Start moving or resizing the window.
        /// 
        /// The user can request the display server to start moving or resizing the window by combining modes from <see cref="CoreUI.UI.WinMoveResizeMode"/>. This API can only be called if none of the following conditions is true:
        /// 
        /// 1. Called in the absence of a pointer down event, 2. Called more than once before a pointer up event, 3. Called when the window is already being resized or moved, 4. Called with an unsupported combination of modes.
        /// 
        /// Right usage: 1. Pointer (mouse or touch) down event, 2. <see cref="CoreUI.UI.Win.MoveResizeStart"/> called only once with a supported mode, 3. Pointer (mouse or touch) up event.
        /// 
        /// If a pointer up event occurs after calling the function, it automatically ends the window move and resize operation.
        /// 
        /// Currently, only the following 9 combinations are allowed, and possibly more combinations may be added in the future: 1. <see cref="CoreUI.UI.WinMoveResizeMode.Move"/> 2. <see cref="CoreUI.UI.WinMoveResizeMode.Top"/> 3. <see cref="CoreUI.UI.WinMoveResizeMode.Bottom"/> 4. <see cref="CoreUI.UI.WinMoveResizeMode.Left"/> 5. <see cref="CoreUI.UI.WinMoveResizeMode.Right"/> 6. <see cref="CoreUI.UI.WinMoveResizeMode.Top"/> | <see cref="CoreUI.UI.WinMoveResizeMode.Left"/> 7. <see cref="CoreUI.UI.WinMoveResizeMode.Top"/> | <see cref="CoreUI.UI.WinMoveResizeMode.Right"/> 8. <see cref="CoreUI.UI.WinMoveResizeMode.Bottom"/> | <see cref="CoreUI.UI.WinMoveResizeMode.Left"/> 9. <see cref="CoreUI.UI.WinMoveResizeMode.Bottom"/> | <see cref="CoreUI.UI.WinMoveResizeMode.Right"/>
        /// 
        /// In particular move and resize cannot happen simultaneously.
        /// 
        /// <b>NOTE: </b>the result of this API can only guarantee that the request has been forwarded to the server, but there is no guarantee that the request can be processed by the display server.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="mode">The requested move or resize mode.</param>
        /// <returns><c>true</c> if the request was successfully sent to the display server, <c>false</c> in case of error.</returns>
        public virtual bool MoveResizeStart(CoreUI.UI.WinMoveResizeMode mode) {
            var _ret_var = CoreUI.UI.Win.NativeMethods.efl_ui_win_move_resize_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), mode);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <returns>The sub-object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.IEntity GetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <param name="content">The sub-object.</param>
        /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetContent(CoreUI.Gfx.IEntity content) {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), content);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Unswallowed object</returns>
        public virtual CoreUI.Gfx.IEntity UnsetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Screen size (in pixels) for the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
        /// <returns>The screen size in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetScreenSizeInPixels() {
            var _ret_var = CoreUI.IScreenNativeMethods.efl_screen_size_in_pixels_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Screen scaling factor.
        /// 
        /// This is the factor by which window contents will be scaled on the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
        /// <returns>The screen scaling factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual float GetScreenScaleFactor() {
            var _ret_var = CoreUI.IScreenNativeMethods.efl_screen_scale_factor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The rotation of the screen.
        /// 
        /// Most engines only return multiples of 90.</summary>
        /// <returns>Screen rotation in degrees.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetScreenRotation() {
            var _ret_var = CoreUI.IScreenNativeMethods.efl_screen_rotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
        /// <param name="xdpi">Horizontal DPI.</param>
        /// <param name="ydpi">Vertical DPI.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetScreenDpi(out int xdpi, out int ydpi) {
            CoreUI.IScreenNativeMethods.efl_screen_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out xdpi, out ydpi);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <returns>Text string to display.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetText() {
            var _ret_var = CoreUI.ITextNativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <param name="text">Text string to display.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetText(System.String text) {
            CoreUI.ITextNativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), text);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The maximum image size the canvas can possibly handle.
        /// 
        /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
        /// 
        /// The default limit is 65535x65535.</summary>
        /// <param name="max">The maximum image size (in pixels).</param>
        /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetImageMaxSize(out CoreUI.DataTypes.Size2D max) {
            var _out_max = new CoreUI.DataTypes.Size2D();
var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_image_max_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_max);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
max = _out_max;
            return _ret_var;
        }

        /// <summary>Get if the canvas is currently calculating group objects.</summary>
        /// <returns><c>true</c> if currently calculating group objects.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetGroupObjectsCalculating() {
            var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_group_objects_calculating_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Call user-provided <c>calculate</c> group functions and unset the flag signalling that the object needs to get recalculated to all group objects in the canvas.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void CalculateGroupObjects() {
            CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_group_objects_calculate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Retrieve a list of objects at a given position in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pos">The pixel position.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
        public virtual IEnumerable<CoreUI.Gfx.IEntity> GetObjectsAtXy(CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_objects_at_xy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos, include_pass_events_objects, include_hidden_objects);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
        }

        /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pos">The pixel position.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The canvas object that is over all other objects at the given position.</returns>
        public virtual CoreUI.Gfx.IEntity GetObjectTopAtXy(CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_object_top_at_xy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos, include_pass_events_objects, include_hidden_objects);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Retrieve a list of objects overlapping a given rectangular region in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rect">The rectangular region.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>Iterator to objects</returns>
        public virtual IEnumerable<CoreUI.Gfx.IEntity> GetObjectsInRectangle(CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
            CoreUI.DataTypes.Rect _in_rect = rect;
var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_objects_in_rectangle_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_rect, include_pass_events_objects, include_hidden_objects);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
        }

        /// <summary>Retrieve the canvas object stacked at the top of a given rectangular region in a canvas
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rect">The rectangular region.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The object that is over all other objects at the given rectangular region.</returns>
        public virtual CoreUI.Gfx.IEntity GetObjectTopInRectangle(CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
            CoreUI.DataTypes.Rect _in_rect = rect;
var _ret_var = CoreUI.Canvas.ISceneNativeMethods.efl_canvas_scene_object_top_in_rectangle_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_rect, include_pass_events_objects, include_hidden_objects);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
        /// 
        /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.</summary>
        /// <value>The type, one of <see cref="CoreUI.UI.WinIndicatorMode"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.WinIndicatorMode IndicatorMode {
            get { return GetIndicatorMode(); }
            set { SetIndicatorMode(value); }
        }

        /// <summary>Enable quitting the main loop when this window is closed.
        /// 
        /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.</summary>
        /// <value>The exit code to use when exiting</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Value ExitOnClose {
            get { return GetExitOnClose(); }
            set { SetExitOnClose(value); }
        }

        /// <summary>A window object&apos;s icon.
        /// 
        /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> or <see cref="CoreUI.UI.Image"/> are allowed.</summary>
        /// <value>The image object to use for an icon.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object IconObject {
            get { return GetIconObject(); }
            set { SetIconObject(value); }
        }

        /// <summary>The minimized state of a window.</summary>
        /// <value>If <c>true</c>, the window is minimized.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Minimized {
            get { return GetMinimized(); }
            set { SetMinimized(value); }
        }

        /// <summary>The maximized state of a window.</summary>
        /// <value>If <c>true</c>, the window is maximized.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Maximized {
            get { return GetMaximized(); }
            set { SetMaximized(value); }
        }

        /// <summary>The fullscreen state of a window.</summary>
        /// <value>If <c>true</c>, the window is fullscreen.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Fullscreen {
            get { return GetFullscreen(); }
            set { SetFullscreen(value); }
        }

        /// <summary>The window name.
        /// 
        /// The meaning of name depends on the underlying windowing system.
        /// 
        /// The window name is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
        /// 
        /// <b>NOTE: </b>Once set, it cannot be modified afterwards.</summary>
        /// <value>Window name</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String WinName {
            get { return GetWinName(); }
            set { SetWinName(value); }
        }

        /// <summary>The alpha channel state of a window.
        /// 
        /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
        /// 
        /// <b>NOTE: </b>Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.</summary>
        /// <value><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Alpha {
            get { return GetAlpha(); }
            set { SetAlpha(value); }
        }

        /// <summary>Enable quitting the main loop when all windows are closed.
        /// 
        /// When set, the main loop will quit with the passed exit code once all windows have been closed.
        /// 
        /// The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
        /// 
        /// Note this is different from <see cref="CoreUI.UI.Win.ExitOnClose"/> which exits when a given window is closed.</summary>
        /// <value>The exit code to use when exiting.</value>
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.DataTypes.Value ExitOnAllWindowsClosed {
            get { return GetExitOnAllWindowsClosed(); }
            set { SetExitOnAllWindowsClosed(value); }
        }

        /// <summary>Base size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.
        /// 
        /// See also <see cref="CoreUI.UI.Win.HintStep"/>.</summary>
        /// <value>Base size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintBase {
            get { return GetHintBase(); }
            set { SetHintBase(value); }
        }

        /// <summary>Step size for objects with sizing restrictions.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Set this to for an object to scale up by steps and not continuously.
        /// 
        /// <see cref="CoreUI.UI.Win.HintBase"/> + N x <see cref="CoreUI.UI.Win.HintStep"/> is what is calculated for object sizing restrictions.</summary>
        /// <value>Step size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintStep {
            get { return GetHintStep(); }
            set { SetHintStep(value); }
        }

        /// <summary>Whether focus highlight is enabled or not on this window, regardless of the global setting.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <value>The enabled value for the highlight.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool FocusHighlightEnabled {
            get { return GetFocusHighlightEnabled(); }
            set { SetFocusHighlightEnabled(value); }
        }

        /// <summary>Control the widget focus highlight style.
        /// 
        /// If <c>style</c> is <c>null</c>, the default will be used.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightAnimate"/>.</summary>
        /// <value>The name of the focus highlight style.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String FocusHighlightStyle {
            get { return GetFocusHighlightStyle(); }
            set { SetFocusHighlightStyle(value); }
        }

        /// <summary>Whether focus highlight should animate or not.
        /// 
        /// See also <see cref="CoreUI.UI.Win.FocusHighlightStyle"/>. See also <see cref="CoreUI.UI.Win.FocusHighlightEnabled"/>.</summary>
        /// <value>The enabled value for the highlight animation.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool FocusHighlightAnimate {
            get { return GetFocusHighlightAnimate(); }
            set { SetFocusHighlightAnimate(value); }
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <value>The sub-object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Content {
            get { return GetContent(); }
            set { SetContent(value); }
        }

        /// <summary>Screen size (in pixels) for the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
        /// <value>The screen size in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D ScreenSizeInPixels {
            get { return GetScreenSizeInPixels(); }
        }

        /// <summary>Screen scaling factor.
        /// 
        /// This is the factor by which window contents will be scaled on the screen.
        /// 
        /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
        /// <value>The screen scaling factor.</value>
        /// <since_tizen> 6 </since_tizen>
        public float ScreenScaleFactor {
            get { return GetScreenScaleFactor(); }
        }

        /// <summary>The rotation of the screen.
        /// 
        /// Most engines only return multiples of 90.</summary>
        /// <value>Screen rotation in degrees.</value>
        /// <since_tizen> 6 </since_tizen>
        public int ScreenRotation {
            get { return GetScreenRotation(); }
        }

        /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
        /// <since_tizen> 6 </since_tizen>
        public (int, int) ScreenDpi {
            get {
                int _out_xdpi = default(int);
                int _out_ydpi = default(int);
                GetScreenDpi(out _out_xdpi, out _out_ydpi);
                return (_out_xdpi, _out_ydpi);
            }
        }

        /// <summary>The text string to be displayed by the given text object.
        /// 
        /// Do not release (free) the returned value.</summary>
        /// <value>Text string to display.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Text {
            get { return GetText(); }
            set { SetText(value); }
        }

        /// <summary>The maximum image size the canvas can possibly handle.
        /// 
        /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
        /// 
        /// The default limit is 65535x65535.</summary>
        /// <value><c>true</c> on success, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D ImageMaxSize {
            get {
                CoreUI.DataTypes.Size2D _out_max = default(CoreUI.DataTypes.Size2D);
                GetImageMaxSize(out _out_max);
                return (_out_max);
            }
        }

        /// <summary>Get if the canvas is currently calculating group objects.</summary>
        /// <value><c>true</c> if currently calculating group objects.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool GroupObjectsCalculating {
            get { return GetGroupObjectsCalculating(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Win.efl_ui_win_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Widget.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_win_indicator_mode_get_static_delegate == null)
                {
                    efl_ui_win_indicator_mode_get_static_delegate = new efl_ui_win_indicator_mode_get_delegate(indicator_mode_get);
                }

                if (methods.Contains("GetIndicatorMode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_indicator_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_indicator_mode_get_static_delegate) });
                }

                if (efl_ui_win_indicator_mode_set_static_delegate == null)
                {
                    efl_ui_win_indicator_mode_set_static_delegate = new efl_ui_win_indicator_mode_set_delegate(indicator_mode_set);
                }

                if (methods.Contains("SetIndicatorMode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_indicator_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_indicator_mode_set_static_delegate) });
                }

                if (efl_ui_win_exit_on_close_get_static_delegate == null)
                {
                    efl_ui_win_exit_on_close_get_static_delegate = new efl_ui_win_exit_on_close_get_delegate(exit_on_close_get);
                }

                if (methods.Contains("GetExitOnClose"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_exit_on_close_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_exit_on_close_get_static_delegate) });
                }

                if (efl_ui_win_exit_on_close_set_static_delegate == null)
                {
                    efl_ui_win_exit_on_close_set_static_delegate = new efl_ui_win_exit_on_close_set_delegate(exit_on_close_set);
                }

                if (methods.Contains("SetExitOnClose"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_exit_on_close_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_exit_on_close_set_static_delegate) });
                }

                if (efl_ui_win_icon_object_get_static_delegate == null)
                {
                    efl_ui_win_icon_object_get_static_delegate = new efl_ui_win_icon_object_get_delegate(icon_object_get);
                }

                if (methods.Contains("GetIconObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_icon_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_icon_object_get_static_delegate) });
                }

                if (efl_ui_win_icon_object_set_static_delegate == null)
                {
                    efl_ui_win_icon_object_set_static_delegate = new efl_ui_win_icon_object_set_delegate(icon_object_set);
                }

                if (methods.Contains("SetIconObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_icon_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_icon_object_set_static_delegate) });
                }

                if (efl_ui_win_minimized_get_static_delegate == null)
                {
                    efl_ui_win_minimized_get_static_delegate = new efl_ui_win_minimized_get_delegate(minimized_get);
                }

                if (methods.Contains("GetMinimized"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_minimized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_minimized_get_static_delegate) });
                }

                if (efl_ui_win_minimized_set_static_delegate == null)
                {
                    efl_ui_win_minimized_set_static_delegate = new efl_ui_win_minimized_set_delegate(minimized_set);
                }

                if (methods.Contains("SetMinimized"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_minimized_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_minimized_set_static_delegate) });
                }

                if (efl_ui_win_maximized_get_static_delegate == null)
                {
                    efl_ui_win_maximized_get_static_delegate = new efl_ui_win_maximized_get_delegate(maximized_get);
                }

                if (methods.Contains("GetMaximized"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_maximized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_maximized_get_static_delegate) });
                }

                if (efl_ui_win_maximized_set_static_delegate == null)
                {
                    efl_ui_win_maximized_set_static_delegate = new efl_ui_win_maximized_set_delegate(maximized_set);
                }

                if (methods.Contains("SetMaximized"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_maximized_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_maximized_set_static_delegate) });
                }

                if (efl_ui_win_fullscreen_get_static_delegate == null)
                {
                    efl_ui_win_fullscreen_get_static_delegate = new efl_ui_win_fullscreen_get_delegate(fullscreen_get);
                }

                if (methods.Contains("GetFullscreen"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_fullscreen_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_fullscreen_get_static_delegate) });
                }

                if (efl_ui_win_fullscreen_set_static_delegate == null)
                {
                    efl_ui_win_fullscreen_set_static_delegate = new efl_ui_win_fullscreen_set_delegate(fullscreen_set);
                }

                if (methods.Contains("SetFullscreen"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_fullscreen_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_fullscreen_set_static_delegate) });
                }

                if (efl_ui_win_name_get_static_delegate == null)
                {
                    efl_ui_win_name_get_static_delegate = new efl_ui_win_name_get_delegate(win_name_get);
                }

                if (methods.Contains("GetWinName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_name_get_static_delegate) });
                }

                if (efl_ui_win_name_set_static_delegate == null)
                {
                    efl_ui_win_name_set_static_delegate = new efl_ui_win_name_set_delegate(win_name_set);
                }

                if (methods.Contains("SetWinName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_name_set_static_delegate) });
                }

                if (efl_ui_win_alpha_get_static_delegate == null)
                {
                    efl_ui_win_alpha_get_static_delegate = new efl_ui_win_alpha_get_delegate(alpha_get);
                }

                if (methods.Contains("GetAlpha"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_alpha_get_static_delegate) });
                }

                if (efl_ui_win_alpha_set_static_delegate == null)
                {
                    efl_ui_win_alpha_set_static_delegate = new efl_ui_win_alpha_set_delegate(alpha_set);
                }

                if (methods.Contains("SetAlpha"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_alpha_set_static_delegate) });
                }

                if (efl_ui_win_hint_base_get_static_delegate == null)
                {
                    efl_ui_win_hint_base_get_static_delegate = new efl_ui_win_hint_base_get_delegate(hint_base_get);
                }

                if (methods.Contains("GetHintBase"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_base_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_base_get_static_delegate) });
                }

                if (efl_ui_win_hint_base_set_static_delegate == null)
                {
                    efl_ui_win_hint_base_set_static_delegate = new efl_ui_win_hint_base_set_delegate(hint_base_set);
                }

                if (methods.Contains("SetHintBase"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_base_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_base_set_static_delegate) });
                }

                if (efl_ui_win_hint_step_get_static_delegate == null)
                {
                    efl_ui_win_hint_step_get_static_delegate = new efl_ui_win_hint_step_get_delegate(hint_step_get);
                }

                if (methods.Contains("GetHintStep"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_step_get_static_delegate) });
                }

                if (efl_ui_win_hint_step_set_static_delegate == null)
                {
                    efl_ui_win_hint_step_set_static_delegate = new efl_ui_win_hint_step_set_delegate(hint_step_set);
                }

                if (methods.Contains("SetHintStep"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_step_set_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_enabled_get_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_enabled_get_static_delegate = new efl_ui_win_focus_highlight_enabled_get_delegate(focus_highlight_enabled_get);
                }

                if (methods.Contains("GetFocusHighlightEnabled"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_enabled_get_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_enabled_set_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_enabled_set_static_delegate = new efl_ui_win_focus_highlight_enabled_set_delegate(focus_highlight_enabled_set);
                }

                if (methods.Contains("SetFocusHighlightEnabled"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_enabled_set_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_style_get_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_style_get_static_delegate = new efl_ui_win_focus_highlight_style_get_delegate(focus_highlight_style_get);
                }

                if (methods.Contains("GetFocusHighlightStyle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_style_get_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_style_set_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_style_set_static_delegate = new efl_ui_win_focus_highlight_style_set_delegate(focus_highlight_style_set);
                }

                if (methods.Contains("SetFocusHighlightStyle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_style_set_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_animate_get_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_animate_get_static_delegate = new efl_ui_win_focus_highlight_animate_get_delegate(focus_highlight_animate_get);
                }

                if (methods.Contains("GetFocusHighlightAnimate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_animate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_animate_get_static_delegate) });
                }

                if (efl_ui_win_focus_highlight_animate_set_static_delegate == null)
                {
                    efl_ui_win_focus_highlight_animate_set_static_delegate = new efl_ui_win_focus_highlight_animate_set_delegate(focus_highlight_animate_set);
                }

                if (methods.Contains("SetFocusHighlightAnimate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_animate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_animate_set_static_delegate) });
                }

                if (efl_ui_win_activate_static_delegate == null)
                {
                    efl_ui_win_activate_static_delegate = new efl_ui_win_activate_delegate(activate);
                }

                if (methods.Contains("Activate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_activate_static_delegate) });
                }

                if (efl_ui_win_move_resize_start_static_delegate == null)
                {
                    efl_ui_win_move_resize_start_static_delegate = new efl_ui_win_move_resize_start_delegate(move_resize_start);
                }

                if (methods.Contains("MoveResizeStart"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_move_resize_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_move_resize_start_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Win.efl_ui_win_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.UI.WinIndicatorMode efl_ui_win_indicator_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.UI.WinIndicatorMode efl_ui_win_indicator_mode_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_indicator_mode_get_api_delegate> efl_ui_win_indicator_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_indicator_mode_get_api_delegate>(Module, "efl_ui_win_indicator_mode_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.WinIndicatorMode indicator_mode_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_indicator_mode_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.WinIndicatorMode _ret_var = default(CoreUI.UI.WinIndicatorMode);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetIndicatorMode();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_indicator_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_indicator_mode_get_delegate efl_ui_win_indicator_mode_get_static_delegate;

            
            private delegate void efl_ui_win_indicator_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.WinIndicatorMode type);

            
            internal delegate void efl_ui_win_indicator_mode_set_api_delegate(System.IntPtr obj,  CoreUI.UI.WinIndicatorMode type);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_indicator_mode_set_api_delegate> efl_ui_win_indicator_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_indicator_mode_set_api_delegate>(Module, "efl_ui_win_indicator_mode_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void indicator_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.WinIndicatorMode type)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_indicator_mode_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetIndicatorMode(type);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_indicator_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type);
                }
            }

            private static efl_ui_win_indicator_mode_set_delegate efl_ui_win_indicator_mode_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            private delegate CoreUI.DataTypes.Value efl_ui_win_exit_on_close_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            internal delegate CoreUI.DataTypes.Value efl_ui_win_exit_on_close_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_close_get_api_delegate> efl_ui_win_exit_on_close_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_close_get_api_delegate>(Module, "efl_ui_win_exit_on_close_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Value exit_on_close_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_exit_on_close_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Value _ret_var = default(CoreUI.DataTypes.Value);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetExitOnClose();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_exit_on_close_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_exit_on_close_get_delegate efl_ui_win_exit_on_close_get_static_delegate;

            
            private delegate void efl_ui_win_exit_on_close_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value exit_code);

            
            internal delegate void efl_ui_win_exit_on_close_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value exit_code);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_close_set_api_delegate> efl_ui_win_exit_on_close_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_close_set_api_delegate>(Module, "efl_ui_win_exit_on_close_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void exit_on_close_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Value exit_code)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_exit_on_close_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetExitOnClose(exit_code);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_exit_on_close_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), exit_code);
                }
            }

            private static efl_ui_win_exit_on_close_set_delegate efl_ui_win_exit_on_close_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_win_icon_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_win_icon_object_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_icon_object_get_api_delegate> efl_ui_win_icon_object_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_icon_object_get_api_delegate>(Module, "efl_ui_win_icon_object_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object icon_object_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_icon_object_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetIconObject();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_icon_object_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_icon_object_get_delegate efl_ui_win_icon_object_get_static_delegate;

            
            private delegate void efl_ui_win_icon_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object icon);

            
            internal delegate void efl_ui_win_icon_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object icon);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_icon_object_set_api_delegate> efl_ui_win_icon_object_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_icon_object_set_api_delegate>(Module, "efl_ui_win_icon_object_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void icon_object_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object icon)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_icon_object_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetIconObject(icon);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_icon_object_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), icon);
                }
            }

            private static efl_ui_win_icon_object_set_delegate efl_ui_win_icon_object_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_minimized_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_minimized_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_minimized_get_api_delegate> efl_ui_win_minimized_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_minimized_get_api_delegate>(Module, "efl_ui_win_minimized_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool minimized_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_minimized_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetMinimized();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_minimized_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_minimized_get_delegate efl_ui_win_minimized_get_static_delegate;

            
            private delegate void efl_ui_win_minimized_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool state);

            
            internal delegate void efl_ui_win_minimized_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool state);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_minimized_set_api_delegate> efl_ui_win_minimized_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_minimized_set_api_delegate>(Module, "efl_ui_win_minimized_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void minimized_set(System.IntPtr obj, System.IntPtr pd, bool state)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_minimized_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetMinimized(state);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_minimized_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), state);
                }
            }

            private static efl_ui_win_minimized_set_delegate efl_ui_win_minimized_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_maximized_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_maximized_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_maximized_get_api_delegate> efl_ui_win_maximized_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_maximized_get_api_delegate>(Module, "efl_ui_win_maximized_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool maximized_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_maximized_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetMaximized();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_maximized_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_maximized_get_delegate efl_ui_win_maximized_get_static_delegate;

            
            private delegate void efl_ui_win_maximized_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool maximized);

            
            internal delegate void efl_ui_win_maximized_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool maximized);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_maximized_set_api_delegate> efl_ui_win_maximized_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_maximized_set_api_delegate>(Module, "efl_ui_win_maximized_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void maximized_set(System.IntPtr obj, System.IntPtr pd, bool maximized)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_maximized_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetMaximized(maximized);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_maximized_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), maximized);
                }
            }

            private static efl_ui_win_maximized_set_delegate efl_ui_win_maximized_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_fullscreen_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_fullscreen_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_fullscreen_get_api_delegate> efl_ui_win_fullscreen_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_fullscreen_get_api_delegate>(Module, "efl_ui_win_fullscreen_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool fullscreen_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_fullscreen_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetFullscreen();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_fullscreen_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_fullscreen_get_delegate efl_ui_win_fullscreen_get_static_delegate;

            
            private delegate void efl_ui_win_fullscreen_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool fullscreen);

            
            internal delegate void efl_ui_win_fullscreen_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool fullscreen);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_fullscreen_set_api_delegate> efl_ui_win_fullscreen_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_fullscreen_set_api_delegate>(Module, "efl_ui_win_fullscreen_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void fullscreen_set(System.IntPtr obj, System.IntPtr pd, bool fullscreen)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_fullscreen_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetFullscreen(fullscreen);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_fullscreen_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), fullscreen);
                }
            }

            private static efl_ui_win_fullscreen_set_delegate efl_ui_win_fullscreen_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_ui_win_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_ui_win_name_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_name_get_api_delegate> efl_ui_win_name_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_name_get_api_delegate>(Module, "efl_ui_win_name_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String win_name_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_name_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetWinName();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_name_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_name_get_delegate efl_ui_win_name_get_static_delegate;

            
            private delegate void efl_ui_win_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            
            internal delegate void efl_ui_win_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_name_set_api_delegate> efl_ui_win_name_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_name_set_api_delegate>(Module, "efl_ui_win_name_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void win_name_set(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_name_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetWinName(name);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_name_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_ui_win_name_set_delegate efl_ui_win_name_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_alpha_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_alpha_get_api_delegate> efl_ui_win_alpha_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_alpha_get_api_delegate>(Module, "efl_ui_win_alpha_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_alpha_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetAlpha();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_alpha_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_alpha_get_delegate efl_ui_win_alpha_get_static_delegate;

            
            private delegate void efl_ui_win_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

            
            internal delegate void efl_ui_win_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_alpha_set_api_delegate> efl_ui_win_alpha_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_alpha_set_api_delegate>(Module, "efl_ui_win_alpha_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_alpha_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetAlpha(alpha);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_alpha_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), alpha);
                }
            }

            private static efl_ui_win_alpha_set_delegate efl_ui_win_alpha_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            private delegate CoreUI.DataTypes.Value efl_ui_win_exit_on_all_windows_closed_get_delegate();

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))]
            internal delegate CoreUI.DataTypes.Value efl_ui_win_exit_on_all_windows_closed_get_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_get_api_delegate> efl_ui_win_exit_on_all_windows_closed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_get_api_delegate>(Module, "efl_ui_win_exit_on_all_windows_closed_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Value exit_on_all_windows_closed_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_exit_on_all_windows_closed_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Value _ret_var = default(CoreUI.DataTypes.Value);
                    try
                    {
                        _ret_var = Win.GetExitOnAllWindowsClosed();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_exit_on_all_windows_closed_get_ptr.Value.Delegate();
                }
            }

            
            private delegate void efl_ui_win_exit_on_all_windows_closed_set_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value exit_code);

            
            internal delegate void efl_ui_win_exit_on_all_windows_closed_set_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.ValueMarshaler))] CoreUI.DataTypes.Value exit_code);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_set_api_delegate> efl_ui_win_exit_on_all_windows_closed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_set_api_delegate>(Module, "efl_ui_win_exit_on_all_windows_closed_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void exit_on_all_windows_closed_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Value exit_code)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_exit_on_all_windows_closed_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        Win.SetExitOnAllWindowsClosed(exit_code);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_exit_on_all_windows_closed_set_ptr.Value.Delegate(exit_code);
                }
            }

            
            private delegate CoreUI.DataTypes.Size2D efl_ui_win_hint_base_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Size2D efl_ui_win_hint_base_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_base_get_api_delegate> efl_ui_win_hint_base_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_base_get_api_delegate>(Module, "efl_ui_win_hint_base_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Size2D hint_base_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_hint_base_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetHintBase();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_hint_base_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_hint_base_get_delegate efl_ui_win_hint_base_get_static_delegate;

            
            private delegate void efl_ui_win_hint_base_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

            
            internal delegate void efl_ui_win_hint_base_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_base_set_api_delegate> efl_ui_win_hint_base_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_base_set_api_delegate>(Module, "efl_ui_win_hint_base_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void hint_base_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_hint_base_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _in_sz = sz;

                    try
                    {
                        ((Win)ws.Target).SetHintBase(_in_sz);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_hint_base_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
                }
            }

            private static efl_ui_win_hint_base_set_delegate efl_ui_win_hint_base_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Size2D efl_ui_win_hint_step_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Size2D efl_ui_win_hint_step_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_step_get_api_delegate> efl_ui_win_hint_step_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_step_get_api_delegate>(Module, "efl_ui_win_hint_step_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Size2D hint_step_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_hint_step_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetHintStep();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_hint_step_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_hint_step_get_delegate efl_ui_win_hint_step_get_static_delegate;

            
            private delegate void efl_ui_win_hint_step_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

            
            internal delegate void efl_ui_win_hint_step_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_step_set_api_delegate> efl_ui_win_hint_step_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_hint_step_set_api_delegate>(Module, "efl_ui_win_hint_step_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void hint_step_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_hint_step_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _in_sz = sz;

                    try
                    {
                        ((Win)ws.Target).SetHintStep(_in_sz);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_hint_step_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
                }
            }

            private static efl_ui_win_hint_step_set_delegate efl_ui_win_hint_step_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_focus_highlight_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_focus_highlight_enabled_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_enabled_get_api_delegate> efl_ui_win_focus_highlight_enabled_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_enabled_get_api_delegate>(Module, "efl_ui_win_focus_highlight_enabled_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool focus_highlight_enabled_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_enabled_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetFocusHighlightEnabled();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_focus_highlight_enabled_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_focus_highlight_enabled_get_delegate efl_ui_win_focus_highlight_enabled_get_static_delegate;

            
            private delegate void efl_ui_win_focus_highlight_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

            
            internal delegate void efl_ui_win_focus_highlight_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_enabled_set_api_delegate> efl_ui_win_focus_highlight_enabled_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_enabled_set_api_delegate>(Module, "efl_ui_win_focus_highlight_enabled_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_highlight_enabled_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_enabled_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetFocusHighlightEnabled(enabled);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_focus_highlight_enabled_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enabled);
                }
            }

            private static efl_ui_win_focus_highlight_enabled_set_delegate efl_ui_win_focus_highlight_enabled_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_ui_win_focus_highlight_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_ui_win_focus_highlight_style_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_style_get_api_delegate> efl_ui_win_focus_highlight_style_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_style_get_api_delegate>(Module, "efl_ui_win_focus_highlight_style_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String focus_highlight_style_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_style_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetFocusHighlightStyle();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_focus_highlight_style_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_focus_highlight_style_get_delegate efl_ui_win_focus_highlight_style_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_focus_highlight_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_focus_highlight_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_style_set_api_delegate> efl_ui_win_focus_highlight_style_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_style_set_api_delegate>(Module, "efl_ui_win_focus_highlight_style_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool focus_highlight_style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_style_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).SetFocusHighlightStyle(style);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_focus_highlight_style_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), style);
                }
            }

            private static efl_ui_win_focus_highlight_style_set_delegate efl_ui_win_focus_highlight_style_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_focus_highlight_animate_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_focus_highlight_animate_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_animate_get_api_delegate> efl_ui_win_focus_highlight_animate_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_animate_get_api_delegate>(Module, "efl_ui_win_focus_highlight_animate_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool focus_highlight_animate_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_animate_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).GetFocusHighlightAnimate();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_focus_highlight_animate_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_focus_highlight_animate_get_delegate efl_ui_win_focus_highlight_animate_get_static_delegate;

            
            private delegate void efl_ui_win_focus_highlight_animate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool animate);

            
            internal delegate void efl_ui_win_focus_highlight_animate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool animate);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_animate_set_api_delegate> efl_ui_win_focus_highlight_animate_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_focus_highlight_animate_set_api_delegate>(Module, "efl_ui_win_focus_highlight_animate_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_highlight_animate_set(System.IntPtr obj, System.IntPtr pd, bool animate)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_focus_highlight_animate_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).SetFocusHighlightAnimate(animate);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_focus_highlight_animate_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), animate);
                }
            }

            private static efl_ui_win_focus_highlight_animate_set_delegate efl_ui_win_focus_highlight_animate_set_static_delegate;

            
            private delegate void efl_ui_win_activate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_ui_win_activate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_activate_api_delegate> efl_ui_win_activate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_activate_api_delegate>(Module, "efl_ui_win_activate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void activate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_activate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Win)ws.Target).Activate();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_win_activate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_win_activate_delegate efl_ui_win_activate_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_win_move_resize_start_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.WinMoveResizeMode mode);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_win_move_resize_start_api_delegate(System.IntPtr obj,  CoreUI.UI.WinMoveResizeMode mode);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_win_move_resize_start_api_delegate> efl_ui_win_move_resize_start_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_win_move_resize_start_api_delegate>(Module, "efl_ui_win_move_resize_start");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool move_resize_start(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.WinMoveResizeMode mode)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_win_move_resize_start was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Win)ws.Target).MoveResizeStart(mode);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_win_move_resize_start_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), mode);
                }
            }

            private static efl_ui_win_move_resize_start_delegate efl_ui_win_move_resize_start_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class WinExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.WinIndicatorMode> IndicatorMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.UI.WinIndicatorMode>("indicator_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Value> ExitOnClose<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Value>("exit_on_close", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> IconObject<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("icon_object", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Minimized<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("minimized", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Maximized<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("maximized", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Fullscreen<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("fullscreen", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> WinName<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<System.String>("win_name", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Alpha<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("alpha", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Value> ExitOnAllWindowsClosed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Value>("exit_on_all_windows_closed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintBase<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_base", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintStep<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_step", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> FocusHighlightEnabled<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("focus_highlight_enabled", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> FocusHighlightStyle<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<System.String>("focus_highlight_style", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> FocusHighlightAnimate<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<bool>("focus_highlight_animate", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Text<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Win, T>magic = null) where T : CoreUI.UI.Win {
            return new CoreUI.BindableProperty<System.String>("text", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI {
    /// <summary>Defines the type indicator that can be shown.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum WinIndicatorMode
    {
        /// <summary>Request to deactivate the indicator.</summary>
        /// <since_tizen> 6 </since_tizen>
        Off = 0,
        /// <summary>The indicator icon is opaque, as is the indicator background. The content of window is located at the end of the indicator. The area of indicator and window content are not overlapped.</summary>
        /// <since_tizen> 6 </since_tizen>
        BgOpaque = 1,
        /// <summary>Be translucent the indicator</summary>
        /// <since_tizen> 6 </since_tizen>
        Translucent = 2,
        /// <summary>Transparentizes the indicator</summary>
        /// <since_tizen> 6 </since_tizen>
        Transparent = 3,
        /// <summary>The icon of indicator is opaque, but the background is transparent. The content of window is located under the indicator in Z-order. The area of indicator and window content are overlapped.</summary>
        /// <since_tizen> 6 </since_tizen>
        BgTransparent = 4,
        /// <summary>The indicator is hidden so user can see only the content of window such as in video mode. If user flicks the upper side of window, the indicator is shown temporarily.</summary>
        /// <since_tizen> 6 </since_tizen>
        Hidden = 5,
    }
}

namespace CoreUI.UI {
    /// <summary>Define the move or resize mode of a window.
    /// 
    /// The user can request the display server to start moving or resizing the window by combining these modes. However only limited combinations are allowed.
    /// 
    /// Currently, only the following 9 combinations are permitted. More combinations may be added in future: 1. move, 2. top, 3. bottom, 4. left, 5. right, 6. top | left, 7. top | right, 8. bottom | left, 9. bottom | right.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum WinMoveResizeMode
    {
        /// <summary>Start moving window</summary>
        /// <since_tizen> 6 </since_tizen>
        Move = 1,
        /// <summary>Start resizing window to the top</summary>
        /// <since_tizen> 6 </since_tizen>
        Top = 2,
        /// <summary>Start resizing window to the bottom</summary>
        /// <since_tizen> 6 </since_tizen>
        Bottom = 4,
        /// <summary>Start resizing window to the left</summary>
        /// <since_tizen> 6 </since_tizen>
        Left = 8,
        /// <summary>Start resizing window to the right</summary>
        /// <since_tizen> 6 </since_tizen>
        Right = 16,
    }
}

