/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

extern alias TizenSystemInformation;
using TizenSystemInformation.Tizen.System;
using global::System;
using System.ComponentModel;
using System.Collections.Generic;
using global::System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The window class is used internally for drawing.<br />
    /// The window has an orientation and indicator properties.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Window : BaseHandle
    {
        private static readonly Window instance = Application.Instance?.GetWindow();
        private global::System.Runtime.InteropServices.HandleRef stageCPtr;
        private Layer _rootLayer;
        private string _windowTitle;
        private List<Layer> _childLayers = new List<Layer>();
        private LayoutController localController;

        private bool IsSupportedMultiWindow()
        {
            bool isSupported = false;
            Information.TryGetValue("http://tizen.org/feature/opengles.surfaceless_context", out isSupported);
            return isSupported;
        }

        internal Window(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Window.Upcast(cPtr), cMemoryOwn)
        {
            if (Interop.Stage.IsInstalled())
            {
                stageCPtr = new global::System.Runtime.InteropServices.HandleRef(this, Interop.Stage.GetCurrent());

                localController = new LayoutController(this);
                NUILog.Debug("layoutController id:" + localController.GetId());
            }
        }

        /// <summary>
        /// Creates a new Window.<br />
        /// This creates an extra window in addition to the default main window<br />
        /// </summary>
        /// <param name="windowPosition">The position and size of the Window.</param>
        /// <param name="isTranslucent">Whether Window is translucent.</param>
        /// <returns>A new Window.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <feature> http://tizen.org/feature/opengles.surfaceless_context </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public Window(Rectangle windowPosition = null, bool isTranslucent = false) : this(Interop.Window.New(Rectangle.getCPtr(windowPosition), "", isTranslucent), true)
        {
            if (IsSupportedMultiWindow() == false)
            {
                NUILog.Error("This device does not support surfaceless_context. So Window cannot be created. ");
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a new Window with a specific name.<br />
        /// This creates an extra window in addition to the default main window<br />
        /// </summary>
        /// <param name="name">The name for extra window. </param>
        /// <param name="windowPosition">The position and size of the Window.</param>
        /// <param name="isTranslucent">Whether Window is translucent.</param>
        /// <returns>A new Window.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <feature> http://tizen.org/feature/opengles.surfaceless_context </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public Window(string name, Rectangle windowPosition = null, bool isTranslucent = false) : this(Interop.Window.New(Rectangle.getCPtr(windowPosition), name, isTranslucent), true)
        {
            if (IsSupportedMultiWindow() == false)
            {
                NUILog.Error("This device does not support surfaceless_context. So Window cannot be created. ");
            }
            this._windowTitle = name;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for orientation of the window is the way in which a rectangular page is oriented for normal viewing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum WindowOrientation
        {
            /// <summary>
            /// Portrait orientation. The height of the display area is greater than the width.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Portrait = 0,
            /// <summary>
            /// Landscape orientation. A wide view area is needed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Landscape = 90,
            /// <summary>
            /// Portrait inverse orientation.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PortraitInverse = 180,
            /// <summary>
            /// Landscape inverse orientation.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            LandscapeInverse = 270,
            /// <summary>
            /// No orientation. It is for the preferred orientation
            /// Especially, NoOrientationPreference only has the effect for the preferred orientation.
            /// It is used to unset the preferred orientation with SetPreferredOrientation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            NoOrientationPreference = -1
        }

        /// <summary>
        /// Enumeration for the key grab mode for platform-level APIs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum KeyGrabMode
        {
            /// <summary>
            /// Grabs a key only when on the top of the grabbing-window stack mode.
            /// </summary>
            Topmost = 0,
            /// <summary>
            /// Grabs a key together with the other client window(s) mode.
            /// </summary>
            Shared,
            /// <summary>
            /// Grabs a key exclusively regardless of the grabbing-window's position on the window stack with the possibility of overriding the grab by the other client window mode.
            /// </summary>
            OverrideExclusive,
            /// <summary>
            /// Grabs a key exclusively regardless of the grabbing-window's position on the window stack mode.
            /// </summary>
            Exclusive
        };

        /// <summary>
        /// Enumeration for transition effect's state.
        /// </summary>
        [Obsolete("Please do not use! This will be removed. Please use Window.EffectState instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectStates
        {
            /// <summary>
            /// None state.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectState.None instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,
            /// <summary>
            /// Transition effect is started.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectState.Start instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Start,
            /// <summary>
            /// Transition effect is ended.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectState.End instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            End,
        }

        /// <summary>
        /// Enumeration for transition effect's state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectState
        {
            /// <summary>
            /// None state.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,
            /// <summary>
            /// Transition effect is started.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Start,
            /// <summary>
            /// Transition effect is ended.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            End,
        }

        /// <summary>
        /// Enumeration for transition effect's type.
        /// </summary>
        [Obsolete("Please do not use! This will be removed. Please use Window.EffectType instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectTypes
        {
            /// <summary>
            /// None type.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectType.None instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,
            /// <summary>
            /// Window show effect.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectType.Show instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Show,
            /// <summary>
            /// Window hide effect.
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Window.EffectType.Hide instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Hide,
        }

        /// <summary>
        /// Enumeration for transition effect's type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectType
        {
            /// <summary>
            /// None type.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,
            /// <summary>
            /// Window show effect.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Show,
            /// <summary>
            /// Window hide effect.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Hide,
        }

        /// <summary>
        /// The stage instance property (read-only).<br />
        /// Gets the current window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Window Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets a window type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WindowType Type
        {
            get
            {
                WindowType ret = (WindowType)Interop.Window.GetType(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.Window.SetType(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets/Sets a window title.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Title
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
                SetClass(_windowTitle, "");
            }
        }

        /// <summary>
        /// The rendering behavior of a Window.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public RenderingBehaviorType RenderingBehavior
        {
            get
            {
                return GetRenderingBehavior();
            }
            set
            {
                SetRenderingBehavior(value);
            }
        }

        /// <summary>
        /// The window size property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size
        {
            get
            {
                Size2D ret = GetSize();
                return ret;
            }
        }

        /// <summary>
        /// The background color property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color BackgroundColor
        {
            set
            {
                SetBackgroundColor(value);
            }
            get
            {
                Color ret = GetBackgroundColor();
                return ret;
            }
        }

        /// <summary>
        /// The DPI property (read-only).<br />
        /// Retrieves the DPI of the display device to which the Window is connected.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Dpi
        {
            get
            {
                return GetDpi();
            }
        }

        /// <summary>
        /// The layer count property (read-only).<br />
        /// Queries the number of on-Window layers.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint LayerCount
        {
            get
            {
                return GetLayerCount();
            }
        }

        /// <summary>
        /// Gets or sets a size of the window.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <since_tizen> 4 </since_tizen>
        public Size2D WindowSize
        {
            get
            {
                return GetWindowSize();
            }
            set
            {
                SetWindowSize(value);
            }
        }

        /// <summary>
        /// Gets or sets a position of the window.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <since_tizen> 4 </since_tizen>
        public Position2D WindowPosition
        {
            get
            {
                return GetPosition();
            }
            set
            {
                SetPosition(value);
            }
        }

        /// <summary>
        /// Sets position and size of the window. This API guarantees that
        /// both moving and resizing of window will appear on the screen at once.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle WindowPositionSize
        {
            get
            {
                Position2D position = GetPosition();
                Size2D size = GetSize();
                Rectangle ret = new Rectangle(position.X, position.Y, size.Width, size.Height);
                position.Dispose();
                return ret;
            }
            set
            {
                SetPositionSize(value);
            }
        }

        internal static Vector4 DEFAULT_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Stage.DefaultBackgroundColorGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Vector4 DEBUG_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Stage.DebugBackgroundColorGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal List<Layer> LayersChildren
        {
            get
            {
                return _childLayers;
            }
        }

        /// <summary>
        ///  Get the LayoutController for this Window.
        /// </summary>
        internal LayoutController LayoutController
        {
            get
            {
                return localController;
            }
        }

        /// <summary>
        /// Feed a key-event into the window.
        /// </summary>
        /// <param name="keyEvent">The key event to feed.</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use FeedKey(Key keyEvent) instead!")]
        public static void FeedKeyEvent(Key keyEvent)
        {
            Interop.Window.FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the window accepts a focus or not.
        /// </summary>
        /// <param name="accept">If a focus is accepted or not. The default is true.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAcceptFocus(bool accept)
        {
            Interop.Window.SetAcceptFocus(SwigCPtr, accept);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether the window accepts a focus or not.
        /// </summary>
        /// <returns>True if the window accepts a focus, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFocusAcceptable()
        {
            bool ret = Interop.Window.IsFocusAcceptable(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        /// <summary>
        /// Shows the window if it is hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            Interop.Window.Show(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the window if it is showing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            Interop.Window.Hide(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the window is visible or not.
        /// </summary>
        /// <returns>True if the window is visible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsVisible()
        {
            bool temp = Interop.Window.IsVisible(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return temp;
        }

        /// <summary>
        /// Gets the count of supported auxiliary hints of the window.
        /// </summary>
        /// <returns>The number of supported auxiliary hints.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetSupportedAuxiliaryHintCount()
        {
            uint ret = Interop.Window.GetSupportedAuxiliaryHintCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the supported auxiliary hint string of the window.
        /// </summary>
        /// <param name="index">The index of the supported auxiliary hint lists.</param>
        /// <returns>The auxiliary hint string of the index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetSupportedAuxiliaryHint(uint index)
        {
            string ret = Interop.Window.GetSupportedAuxiliaryHint(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an auxiliary hint of the window.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <param name="value">The value string.</param>
        /// <returns>The ID of created auxiliary hint, or 0 on failure.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint AddAuxiliaryHint(string hint, string value)
        {
            uint ret = Interop.Window.AddAuxiliaryHint(SwigCPtr, hint, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes an auxiliary hint of the window.
        /// </summary>
        /// <param name="id">The ID of the auxiliary hint.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool RemoveAuxiliaryHint(uint id)
        {
            bool ret = Interop.Window.RemoveAuxiliaryHint(SwigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <param name="value">The value string to be set.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetAuxiliaryHintValue(uint id, string value)
        {
            bool ret = Interop.Window.SetAuxiliaryHintValue(SwigCPtr, id, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <returns>The string value of the auxiliary hint ID, or an empty string if none exists.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetAuxiliaryHintValue(uint id)
        {
            string ret = Interop.Window.GetAuxiliaryHintValue(SwigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets an ID of the auxiliary hint string.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <returns>The ID of auxiliary hint string, or 0 on failure.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetAuxiliaryHintId(string hint)
        {
            uint ret = Interop.Window.GetAuxiliaryHintId(SwigCPtr, hint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a region to accept input events.
        /// </summary>
        /// <param name="inputRegion">The region to accept input events.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetInputRegion(Rectangle inputRegion)
        {
            Interop.Window.SetInputRegion(SwigCPtr, Rectangle.getCPtr(inputRegion));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a priority level for the specified notification window.
        /// </summary>
        /// <param name="level">The notification window level.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetNotificationLevel(NotificationLevel level)
        {
            bool ret = Interop.Window.SetNotificationLevel(SwigCPtr, (int)level);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a priority level for the specified notification window.
        /// </summary>
        /// <returns>The notification window level.</returns>
        /// <since_tizen> 3 </since_tizen>
        public NotificationLevel GetNotificationLevel()
        {
            NotificationLevel ret = (NotificationLevel)Interop.Window.GetNotificationLevel(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a transparent window's visual state to opaque. <br />
        /// If a visual state of a transparent window is opaque, <br />
        /// then the window manager could handle it as an opaque window when calculating visibility.
        /// </summary>
        /// <param name="opaque">Whether the window's visual state is opaque.</param>
        /// <remarks>This will have no effect on an opaque window. <br />
        /// It doesn't change transparent window to opaque window but lets the window manager know the visual state of the window.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void SetOpaqueState(bool opaque)
        {
            Interop.Window.SetOpaqueState(SwigCPtr, opaque);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether a transparent window's visual state is opaque or not.
        /// </summary>
        /// <returns>True if the window's visual state is opaque, false otherwise.</returns>
        /// <remarks> The return value has no meaning on an opaque window. </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOpaqueState()
        {
            bool ret = Interop.Window.IsOpaqueState(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a window's screen off mode.
        /// </summary>
        /// <param name="screenOffMode">The screen mode.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool SetScreenOffMode(ScreenOffMode screenOffMode)
        {
            bool ret = Interop.Window.SetScreenOffMode(SwigCPtr, (int)screenOffMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the screen mode of the window.
        /// </summary>
        /// <returns>The screen off mode.</returns>
        /// <since_tizen> 4 </since_tizen>
        public ScreenOffMode GetScreenOffMode()
        {
            ScreenOffMode ret = (ScreenOffMode)Interop.Window.GetScreenOffMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets preferred brightness of the window.
        /// </summary>
        /// <param name="brightness">The preferred brightness (0 to 100).</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetBrightness(int brightness)
        {
            bool ret = Interop.Window.SetBrightness(SwigCPtr, brightness);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the preferred brightness of the window.
        /// </summary>
        /// <returns>The preferred brightness.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetBrightness()
        {
            int ret = Interop.Window.GetBrightness(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the window name and the class string.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <param name="klass">The class of the window.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetClass(string name, string klass)
        {
            Interop.Window.SetClass(SwigCPtr, name, klass);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Raise()
        {
            Interop.Window.Raise(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers the window to the bottom of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Lower()
        {
            Interop.Window.Lower(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates the window to the top of the window stack even it is iconified.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Activate()
        {
            Interop.Window.Activate(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the default ( root ) layer.
        /// </summary>
        /// <returns>The root layer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Layer GetDefaultLayer()
        {
            return this.GetRootLayer();
        }

        /// <summary>
        /// Add a child view to window.
        /// </summary>
        /// <param name="view">the child should be added to the window.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(View view)
        {
            Interop.Actor.Add(Layer.getCPtr(GetRootLayer()), View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.GetRootLayer().AddViewToLayerList(view); // Maintain the children list in the Layer
            if (null != view)
            {
                view.InternalParent = this.GetRootLayer();
            }
        }

        /// <summary>
        /// Remove a child view from window.
        /// </summary>
        /// <param name="view">the child to be removed.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Remove(View view)
        {
            Interop.Actor.Remove(Layer.getCPtr(GetRootLayer()), View.getCPtr(view));
            this.GetRootLayer().RemoveViewFromLayerList(view); // Maintain the children list in the Layer
            if (null != view)
            {
                view.InternalParent = null;
            }
        }

        /// <summary>
        /// Retrieves the layer at a specified depth.
        /// </summary>
        /// <param name="depth">The layer's depth index.</param>
        /// <returns>The layer found at the given depth.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Layer GetLayer(uint depth)
        {
            if (depth < LayersChildren?.Count)
            {
                Layer ret = LayersChildren?[Convert.ToInt32(depth)];
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Destroy the window immediately.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Destroy()
        {
            this.Dispose();
        }

        /// <summary>
        /// Keep rendering for at least the given amount of time.
        /// </summary>
        /// <param name="durationSeconds">Time to keep rendering, 0 means render at least one more frame.</param>
        /// <since_tizen> 3 </since_tizen>
        public void KeepRendering(float durationSeconds)
        {
            Interop.Stage.KeepRendering(stageCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Grabs the key specified by a key for a window only when a window is the topmost window.<br />
        /// This function can be used for following example scenarios: <br />
        /// - Mobile - Using volume up or down as zoom up or down in camera apps.<br />
        /// </summary>
        /// <param name="DaliKey">The key code to grab.</param>
        /// <returns>True if the grab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GrabKeyTopmost(int DaliKey)
        {
            bool ret = Interop.Window.GrabKeyTopmost(HandleRef.ToIntPtr(this.SwigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for the window.<br />
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event.<br />
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab.</param>
        /// <returns>True if the ungrab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool UngrabKeyTopmost(int DaliKey)
        {
            bool ret = Interop.Window.UngrabKeyTopmost(HandleRef.ToIntPtr(this.SwigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        ///  Grabs the key specified by a key for a window in a GrabMode. <br />
        ///  Details: This function can be used for following example scenarios: <br />
        ///  - TV - A user might want to change the volume or channel of the background TV contents while focusing on the foregrund app. <br />
        ///  - Mobile - When a user presses the Home key, the homescreen appears regardless of the current foreground app. <br />
        ///  - Mobile - Using the volume up or down as zoom up or down in camera apps. <br />
        /// </summary>
        /// <param name="DaliKey">The key code to grab.</param>
        /// <param name="GrabMode">The grab mode for the key.</param>
        /// <returns>True if the grab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GrabKey(int DaliKey, KeyGrabMode GrabMode)
        {
            bool ret = Interop.Window.GrabKey(HandleRef.ToIntPtr(this.SwigCPtr), DaliKey, (int)GrabMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for a window.<br />
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event. <br />
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab.</param>
        /// <returns>True if the ungrab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool UngrabKey(int DaliKey)
        {
            bool ret = Interop.Window.UngrabKey(HandleRef.ToIntPtr(this.SwigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the keyboard repeat information.
        /// </summary>
        /// <param name="rate">The key repeat rate value in seconds.</param>
        /// <param name="delay">The key repeat delay value in seconds.</param>
        /// <returns>True if setting the keyboard repeat succeeds.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool SetKeyboardRepeatInfo(float rate, float delay)
        {
            bool ret = Interop.Window.SetKeyboardRepeatInfo(rate, delay);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the keyboard repeat information.
        /// </summary>
        /// <param name="rate">The key repeat rate value in seconds.</param>
        /// <param name="delay">The key repeat delay value in seconds.</param>
        /// <returns>True if setting the keyboard repeat succeeds.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool GetKeyboardRepeatInfo(out float rate, out float delay)
        {
            bool ret = Interop.Window.GetKeyboardRepeatInfo(out rate, out delay);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a layer to the stage.
        /// </summary>
        /// <param name="layer">Layer to add.</param>
        /// <exception cref="ArgumentNullException"> Thrown when layer is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddLayer(Layer layer)
        {
            Add(layer);
        }

        /// <summary>
        /// Removes a layer from the stage.
        /// </summary>
        /// <param name="layer">Layer to remove.</param>
        /// <exception cref="ArgumentNullException"> Thrown when layer is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveLayer(Layer layer)
        {
            Remove(layer);
        }

        /// <summary>
        /// Feeds a key event into the window.
        /// </summary>
        /// <param name="keyEvent">The key event to feed.</param>
        /// <since_tizen> 5 </since_tizen>
        public void FeedKey(Key keyEvent)
        {
            Interop.Window.FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows at least one more render, even when paused.
        /// The window should be shown, not minimised.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void RenderOnce()
        {
            Interop.Window.RenderOnce(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the window is transparent or not.
        /// </summary>
        /// <param name="transparent">Whether the window is transparent or not.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetTransparency(bool transparent)
        {
            Interop.Window.SetTransparency(SwigCPtr, transparent);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // Setting transparency of the window should request a relayout of the tree in the case the window changes from fully transparent.
        }

        /// <summary>
        /// Sets parent window of the window.
        /// After setting that, these windows do together when raise-up, lower and iconified/deiconified.
        /// Initially, the window is located on top of the parent. The window can go below parent by calling Lower().
        /// If parent's window stack is changed by calling Raise() or Lower(), child windows are located on top of the parent again.
        /// </summary>
        /// <param name="parent">The parent window.</param>
        /// <since_tizen> 6 </since_tizen>
        /// <feature> http://tizen.org/feature/opengles.surfaceless_context </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public void SetParent(Window parent)
        {
            if (IsSupportedMultiWindow() == false)
            {
                NUILog.Error("This device does not support surfaceless_context. So Window cannot be created. ");
            }
            Interop.Window.SetParent(SwigCPtr, Window.getCPtr(parent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unsets parent window of the window.
        /// After unsetting, the window is disconnected his parent window.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature> http://tizen.org/feature/opengles.surfaceless_context </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public void Unparent()
        {
            if (IsSupportedMultiWindow() == false)
            {
                NUILog.Error("Fail to create window. because this device does not support opengles.surfaceless_context.");
            }
            Interop.Window.Unparent(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets parent window of the window.
        /// </summary>
        /// <returns>The parent window of the window.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <feature> http://tizen.org/feature/opengles.surfaceless_context </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public Window GetParent()
        {
            if (IsSupportedMultiWindow() == false)
            {
                NUILog.Error("This device does not support surfaceless_context. So Window cannot be created. ");
            }
            Window ret = Registry.GetManagedBaseHandleFromNativePtr(Interop.Window.GetParent(SwigCPtr)) as Window;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ObjectDump()
        {
            Layer rootLayer = GetRootLayer();
            foreach (View view in rootLayer.Children)
            {
                view.ObjectDump();
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Window obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static bool IsInstalled()
        {
            bool ret = Interop.Stage.IsInstalled();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds an orientation to the list of available orientations.
        /// </summary>
        /// <param name="orientation">The available orientation to add</param>
        /// <since_tizen> 6 </since_tizen>
        public void AddAvailableOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.AddAvailableOrientation(SwigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes an orientation from the list of available orientations.
        /// </summary>
        /// <param name="orientation">The available orientation to remove.</param>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveAvailableOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.RemoveAvailableOrientation(SwigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a preferred orientation.
        /// </summary>
        /// <param name="orientation">The preferred orientation.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetPreferredOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.SetPreferredOrientation(SwigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the preferred orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The preferred orientation if previously set, or none.</returns>
        public Window.WindowOrientation GetPreferredOrientation()
        {
            Window.WindowOrientation ret = (Window.WindowOrientation)Interop.Window.GetPreferredOrientation(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets current orientation of the window.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The current window orientation if previously set, or none.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window.WindowOrientation GetCurrentOrientation()
        {
            Window.WindowOrientation ret = (Window.WindowOrientation)Interop.Window.GetCurrentOrientation(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets available orientations of the window.
        /// This API is for setting several orientations one time.
        /// </summary>
        /// <param name="orientations">The list of orientations.</param>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAvailableOrientations(List<Window.WindowOrientation> orientations)
        {
            PropertyArray orientationArray = new PropertyArray();
            if (null != orientations)
            {
                for (int i = 0; i < orientations.Count; i++)
                {
                    PropertyValue value = new PropertyValue((int)orientations[i]);
                    orientationArray.PushBack(value);
                }
            }

            Interop.Window.SetAvailableOrientations(SwigCPtr, PropertyArray.getCPtr(orientationArray));
            for (uint i = 0; i < orientationArray.Count(); i++)
            {
                orientationArray[i].Dispose();
            }
            orientationArray.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get native window ID
        /// </summary>
        /// <returns>native window ID</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetNativeId()
        {
            int ret = Interop.Window.GetNativeId(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeHandle()
        {
            Any ret = new Any(Interop.WindowInternal.WindowGetNativeHandle(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Add(Layer layer)
        {
            if (null == layer)
            {
                throw new ArgumentNullException(nameof(layer));
            }
            Interop.Window.Add(SwigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Add(layer);
            layer.SetWindow(this);
        }

        internal void Remove(Layer layer)
        {
            if (null == layer)
            {
                throw new ArgumentNullException(nameof(layer));
            }
            Interop.Window.Remove(SwigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Remove(layer);
            layer.SetWindow(null);
        }

        internal Vector2 GetSize()
        {
            var val = new Uint16Pair(Interop.Window.GetSize(SwigCPtr), false);
            Vector2 ret = new Vector2(val.GetWidth(), val.GetHeight());
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskList GetRenderTaskList()
        {
            RenderTaskList ret = new RenderTaskList(Interop.Stage.GetRenderTaskList(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of on-window layers.
        /// </summary>
        /// <returns>The number of layers.</returns>
        /// <remarks>Note that a default layer is always provided (count >= 1).</remarks>
        internal uint GetLayerCount()
        {
            if (LayersChildren == null || LayersChildren.Count < 0)
                return 0;

            return (uint)LayersChildren.Count;
        }

        internal Layer GetRootLayer()
        {
            // Window.IsInstalled() is actually true only when called from event thread and
            // Core has been initialized, not when Stage is ready.
            if (_rootLayer == null && Window.IsInstalled())
            {
                _rootLayer = new Layer(Interop.Window.GetRootLayer(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                LayersChildren?.Add(_rootLayer);
                _rootLayer.SetWindow(this);
            }
            return _rootLayer;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            Interop.Window.SetBackgroundColor(SwigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.Window.GetBackgroundColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector2 GetDpi()
        {
            Vector2 ret = new Vector2(Interop.Stage.GetDpi(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ObjectRegistry GetObjectRegistry()
        {
            ObjectRegistry ret = new ObjectRegistry(Interop.Stage.GetObjectRegistry(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetRenderingBehavior(RenderingBehaviorType renderingBehavior)
        {
            Interop.Stage.SetRenderingBehavior(stageCPtr, (int)renderingBehavior);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RenderingBehaviorType GetRenderingBehavior()
        {
            RenderingBehaviorType ret = (RenderingBehaviorType)Interop.Stage.GetRenderingBehavior(stageCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetWindowSize(Size2D size)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var val = new Uint16Pair((uint)size.Width, (uint)size.Height);
            Interop.Window.SetSize(SwigCPtr, Uint16Pair.getCPtr(val));
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            // Resetting Window size should request a relayout of the tree.
        }

        internal Size2D GetWindowSize()
        {
            var val = new Uint16Pair(Interop.Window.GetSize(SwigCPtr), false);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(Position2D position)
        {
            if (null == position)
            {
                throw new ArgumentNullException(nameof(position));
            }
            var val = new Uint16Pair((uint)position.X, (uint)position.Y);
            Interop.Window.SetPosition(SwigCPtr, Uint16Pair.getCPtr(val));
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            // Setting Position of the window should request a relayout of the tree.
        }

        internal Position2D GetPosition()
        {
            var val = new Uint16Pair(Interop.Window.GetPosition(SwigCPtr), true);
            Position2D ret = new Position2D(val.GetX(), val.GetY());
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPositionSize(Rectangle positionSize)
        {
            Interop.Window.SetPositionSize(SwigCPtr, Rectangle.getCPtr(positionSize));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // Setting Position of the window should request a relayout of the tree.
        }

        /// <summary>
        /// Add FrameUpdateCallback
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddFrameUpdateCallback(FrameUpdateCallbackInterface frameUpdateCallback)
        {
            frameUpdateCallback?.AddFrameUpdateCallback(stageCPtr, Layer.getCPtr(GetRootLayer()));
        }

        /// <summary>
        /// Remove FrameUpdateCallback
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveFrameUpdateCallback(FrameUpdateCallbackInterface frameUpdateCallback)
        {
            frameUpdateCallback?.RemoveFrameUpdateCallback(stageCPtr);
        }

        /// <summary>
        /// Dispose for Window
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                if (_rootLayer != null)
                {
                    _rootLayer.Dispose();
                }

                localController?.Dispose();

                foreach (var layer in _childLayers)
                {
                    if (layer != null)
                    {
                        layer.Dispose();
                    }
                }

                _childLayers.Clear();
            }

            this.DisconnectNativeSignals();

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Window.DeleteWindow(swigCPtr);
        }

        private static Dictionary<int, internalHookCallbackType> frameCallbackList = new Dictionary<int, internalHookCallbackType>();

        private static readonly object locker = new object();

        private static int key = 0;

        private static FrameCallbackType internalHookFrameCallback = OnInternalHookFrameCallback;

        private struct internalHookCallbackType
        {
            public FrameCallbackType userCallback;
            public int frameId;
        }

        private static void OnInternalHookFrameCallback(int id)
        {
            lock (locker)
            {
                if (frameCallbackList.ContainsKey(id))
                {
                    if (frameCallbackList[id].userCallback != null)
                    {
                        frameCallbackList[id].userCallback.Invoke(frameCallbackList[id].frameId);
                        frameCallbackList.Remove(id);
                    }
                    else
                    {
                        NUILog.Error($"found userCallback is NULL");
                        frameCallbackList.Remove(id);
                    }
                }
            }
        }

        private int AddInterHookCallback(FrameCallbackType callback, int frameId)
        {
            if (null == callback)
            {
                throw new ArgumentNullException(nameof(callback), "FrameCallbackType should not be null");
            }
            var assignedKey = 0;
            lock (locker)
            {
                key++;
                assignedKey = key;
                frameCallbackList.Add(assignedKey, new internalHookCallbackType()
                {
                    userCallback = callback,
                    frameId = frameId,
                });
            }
            return assignedKey;
        }

        /// <summary>
        /// Type of callback which is called when the frame rendering is done by graphics driver or when the frame is displayed on display.
        /// </summary>
        /// <param name="frameId">The Id to specify the frame. It will be passed when the callback is called.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void FrameCallbackType(int frameId);

        /// <summary>
        /// Adds a callback that is called when the frame rendering is done by the graphics driver.
        /// A callback of the following type may be used:
        /// <code>
        /// void MyFunction( int frameId )
        /// </code>
        /// This callback will be deleted once it is called.
        /// <remarks>
        /// Ownership of the callback is passed onto this class
        /// </remarks>
        /// </summary>
        /// <param name="callback">The function to call</param>
        /// <param name="frameId">The Id to specify the frame. It will be passed when the callback is called.</param>
        /// <exception cref="ArgumentNullException">This exception can occur by the callback is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddFrameRenderedCallback(FrameCallbackType callback, int frameId)
        {
            var assignedKey = AddInterHookCallback(callback, frameId);
            Interop.WindowInternal.AddFrameRenderedCallback(SwigCPtr, new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(internalHookFrameCallback)), assignedKey);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a callback that is called when the frame is displayed on the display.
        /// A callback of the following type may be used:
        /// <code>
        /// void MyFunction( int frameId )
        /// </code>
        /// This callback will be deleted once it is called.
        /// <remarks>
        /// Ownership of the callback is passed onto this class
        /// </remarks>
        /// </summary>
        /// <param name="callback">The function to call</param>
        /// <param name="frameId">The Id to specify the frame. It will be passed when the callback is called.</param>
        /// <exception cref="ArgumentNullException">This exception can occur by the callback is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddFramePresentedCallback(FrameCallbackType callback, int frameId)
        {
            var assignedKey = AddInterHookCallback(callback, frameId);
            Interop.WindowInternal.AddFramePresentedCallback(SwigCPtr, new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(internalHookFrameCallback)), assignedKey);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
