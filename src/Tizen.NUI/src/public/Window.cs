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
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        internal Window(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Window.Window_SWIGUpcast(cPtr), cMemoryOwn)
        {
            if (Interop.Stage.Stage_IsInstalled())
            {
                stageCPtr = new global::System.Runtime.InteropServices.HandleRef(this, Interop.Stage.Stage_GetCurrent());

                localController = new LayoutController(this);
                NUILog.Debug("layoutController id:" + localController.GetId() );
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
        public Window(Rectangle windowPosition = null , bool isTranslucent = false) : this(Interop.Window.Window_New__SWIG_0(Rectangle.getCPtr(windowPosition), "", isTranslucent), true)
        {
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
        public Window(string name, Rectangle windowPosition = null, bool isTranslucent = false) : this(Interop.Window.Window_New__SWIG_0(Rectangle.getCPtr(windowPosition), name, isTranslucent), true)
        {
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
            LandscapeInverse = 270
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectStates
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EffectTypes
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
        /// Enumeration for opacity of the indicator.
        /// </summary>
        internal enum IndicatorBackgroundOpacity
        {
            Opaque = 100,
            Translucent = 50,
            Transparent = 0
        }

        /// <summary>
        /// Enumeration for visible mode of the indicator.
        /// </summary>
        internal enum IndicatorVisibleMode
        {
            Invisible = 0,
            Visible = 1,
            Auto = 2
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
                WindowType ret = (WindowType)Interop.Window.GetType(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                Interop.Window.SetType(swigCPtr, (int)value);
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
                global::System.IntPtr cPtr = Interop.Stage.Stage_DEFAULT_BACKGROUND_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Vector4 DEBUG_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Stage.Stage_DEBUG_BACKGROUND_COLOR_get();
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
            Interop.Window.Window_FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the window accepts a focus or not.
        /// </summary>
        /// <param name="accept">If a focus is accepted or not. The default is true.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAcceptFocus(bool accept)
        {
            Interop.Window.SetAcceptFocus(swigCPtr, accept);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether the window accepts a focus or not.
        /// </summary>
        /// <returns>True if the window accepts a focus, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFocusAcceptable()
        {
            bool ret = Interop.Window.IsFocusAcceptable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        /// <summary>
        /// Shows the window if it is hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            Interop.Window.Show(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the window if it is showing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            Interop.Window.Hide(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the window is visible or not.
        /// </summary>
        /// <returns>True if the window is visible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsVisible()
        {
            bool temp = Interop.Window.IsVisible(swigCPtr);
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
            uint ret = Interop.Window.GetSupportedAuxiliaryHintCount(swigCPtr);
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
            string ret = Interop.Window.GetSupportedAuxiliaryHint(swigCPtr, index);
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
            uint ret = Interop.Window.AddAuxiliaryHint(swigCPtr, hint, value);
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
            bool ret = Interop.Window.RemoveAuxiliaryHint(swigCPtr, id);
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
            bool ret = Interop.Window.SetAuxiliaryHintValue(swigCPtr, id, value);
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
            string ret = Interop.Window.GetAuxiliaryHintValue(swigCPtr, id);
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
            uint ret = Interop.Window.GetAuxiliaryHintId(swigCPtr, hint);
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
            Interop.Window.SetInputRegion(swigCPtr, Rectangle.getCPtr(inputRegion));
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
            bool ret = Interop.Window.SetNotificationLevel(swigCPtr, (int)level);
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
            NotificationLevel ret = (NotificationLevel)Interop.Window.GetNotificationLevel(swigCPtr);
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
            Interop.Window.SetOpaqueState(swigCPtr, opaque);
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
            bool ret = Interop.Window.IsOpaqueState(swigCPtr);
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
            bool ret = Interop.Window.SetScreenOffMode(swigCPtr, (int)screenOffMode);
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
            ScreenOffMode ret = (ScreenOffMode)Interop.Window.GetScreenOffMode(swigCPtr);
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
            bool ret = Interop.Window.SetBrightness(swigCPtr, brightness);
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
            int ret = Interop.Window.GetBrightness(swigCPtr);
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
            Interop.Window.Window_SetClass(swigCPtr, name, klass);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Raise()
        {
            Interop.Window.Window_Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers the window to the bottom of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Lower()
        {
            Interop.Window.Window_Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates the window to the top of the window stack even it is iconified.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Activate()
        {
            Interop.Window.Window_Activate(swigCPtr);
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
            Interop.Actor.Actor_Add(Layer.getCPtr(GetRootLayer()), View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.GetRootLayer().AddViewToLayerList(view); // Maintain the children list in the Layer
            view.InternalParent = this.GetRootLayer();
        }

        /// <summary>
        /// Remove a child view from window.
        /// </summary>
        /// <param name="view">the child to be removed.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Remove(View view)
        {
            Interop.Actor.Actor_Remove(Layer.getCPtr(GetRootLayer()), View.getCPtr(view));
            this.GetRootLayer().RemoveViewFromLayerList(view); // Maintain the children list in the Layer
            view.InternalParent = null;
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
            Interop.Stage.Stage_KeepRendering(stageCPtr, durationSeconds);
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
            bool ret = Interop.Window.GrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
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
            bool ret = Interop.Window.UngrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
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
            bool ret = Interop.Window.GrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey, (int)GrabMode);
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
            bool ret = Interop.Window.UngrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
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
        /// <since_tizen> 3 </since_tizen>
        public void AddLayer(Layer layer)
        {
            Interop.Window.Add(swigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Add(layer);
            layer.SetWindow(this);
        }

        /// <summary>
        /// Removes a layer from the stage.
        /// </summary>
        /// <param name="layer">Layer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveLayer(Layer layer)
        {
            Interop.Window.Remove(swigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Remove(layer);
            layer.SetWindow(null);
        }

        /// <summary>
        /// Feeds a key event into the window.
        /// </summary>
        /// <param name="keyEvent">The key event to feed.</param>
        /// <since_tizen> 5 </since_tizen>
        public void FeedKey(Key keyEvent)
        {
            Interop.Window.Window_FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows at least one more render, even when paused.
        /// The window should be shown, not minimised.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void RenderOnce()
        {
            Interop.Window.Window_RenderOnce(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the window is transparent or not.
        /// </summary>
        /// <param name="transparent">Whether the window is transparent or not.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetTransparency(bool transparent)
        {
            Interop.Window.SetTransparency(swigCPtr, transparent);
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
        public void SetParent(Window parent)
        {
            Interop.Window.SetParent(swigCPtr, Window.getCPtr(parent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unsets parent window of the window.
        /// After unsetting, the window is disconnected his parent window.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Unparent()
        {
            Interop.Window.Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets parent window of the window.
        /// </summary>
        /// <returns>The parent window of the window.</returns>
        /// <since_tizen> 6 </since_tizen>
        public Window GetParent()
        {
            Window ret = Registry.GetManagedBaseHandleFromNativePtr(Interop.Window.GetParent(swigCPtr)) as Window;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Window obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Window GetCurrent()
        {
            Window ret = new Window(Interop.Stage.Stage_GetCurrent(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static bool IsInstalled()
        {
            bool ret = Interop.Stage.Stage_IsInstalled();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ShowIndicator(Window.IndicatorVisibleMode visibleMode)
        {
            Interop.WindowInternal.Window_ShowIndicator(swigCPtr, (int)visibleMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetIndicatorBackgroundOpacity(Window.IndicatorBackgroundOpacity opacity)
        {
            Interop.WindowInternal.Window_SetIndicatorBgOpacity(swigCPtr, (int)opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateIndicator(Window.WindowOrientation orientation)
        {
            Interop.WindowInternal.Window_RotateIndicator(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds an orientation to the list of available orientations.
        /// </summary>
        /// <param name="orientation">The available orientation to add</param>
        /// <since_tizen> 6 </since_tizen>
        public void AddAvailableOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.Window_AddAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes an orientation from the list of available orientations.
        /// </summary>
        /// <param name="orientation">The available orientation to remove.</param>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveAvailableOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.Window_RemoveAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a preferred orientation.
        /// </summary>
        /// <param name="orientation">The preferred orientation.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetPreferredOrientation(Window.WindowOrientation orientation)
        {
            Interop.Window.Window_SetPreferredOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the preferred orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The preferred orientation if previously set, or none.</returns>
        public Window.WindowOrientation GetPreferredOrientation()
        {
            Window.WindowOrientation ret = (Window.WindowOrientation)Interop.Window.Window_GetPreferredOrientation(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeHandle()
        {
            Any ret = new Any(Interop.WindowInternal.Window_GetNativeHandle(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Add(Layer layer)
        {
            Interop.Window.Add(swigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Add(layer);
            layer.SetWindow(this);
        }

        internal void Remove(Layer layer)
        {
            Interop.Window.Remove(swigCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Remove(layer);
            layer.SetWindow(null);
        }

        internal Vector2 GetSize()
        {
            var val = new Uint16Pair(Interop.Window.GetSize(swigCPtr), false);
            Vector2 ret = new Vector2(val.GetWidth(), val.GetHeight());
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskList GetRenderTaskList()
        {
            RenderTaskList ret = new RenderTaskList(Interop.Stage.Stage_GetRenderTaskList(stageCPtr), true);
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

            return (uint) LayersChildren.Count;
        }

        internal Layer GetRootLayer()
        {
            // Window.IsInstalled() is actually true only when called from event thread and
            // Core has been initialized, not when Stage is ready.
            if (_rootLayer == null && Window.IsInstalled())
            {
                _rootLayer = new Layer(Interop.Window.GetRootLayer(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                LayersChildren?.Add(_rootLayer);
                _rootLayer.SetWindow(this);
            }
            return _rootLayer;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            Interop.Window.SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.Window.GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector2 GetDpi()
        {
            Vector2 ret = new Vector2(Interop.Stage.Stage_GetDpi(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ObjectRegistry GetObjectRegistry()
        {
            ObjectRegistry ret = new ObjectRegistry(Interop.Stage.Stage_GetObjectRegistry(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetRenderingBehavior(RenderingBehaviorType renderingBehavior)
        {
            Interop.Stage.Stage_SetRenderingBehavior(stageCPtr, (int)renderingBehavior);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RenderingBehaviorType GetRenderingBehavior()
        {
            RenderingBehaviorType ret = (RenderingBehaviorType)Interop.Stage.Stage_GetRenderingBehavior(stageCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetWindowSize(Size2D size)
        {
            var val = new Uint16Pair((uint)size.Width, (uint)size.Height);
            Interop.Window.SetSize(swigCPtr, Uint16Pair.getCPtr(val));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // Resetting Window size should request a relayout of the tree.
        }

        internal Size2D GetWindowSize()
        {
            var val = new Uint16Pair(Interop.Window.GetSize(swigCPtr), false);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(Position2D position)
        {
            var val = new Uint16Pair((uint)position.X, (uint)position.Y);
            Interop.Window.SetPosition(swigCPtr, Uint16Pair.getCPtr(val));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            // Setting Position of the window should request a relayout of the tree.
        }

        internal Position2D GetPosition()
        {
            var val = new Uint16Pair(Interop.Window.GetPosition(swigCPtr), true);
            Position2D ret = new Position2D(val.GetX(), val.GetY());

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPositionSize(Rectangle positionSize)
        {
            Interop.Window.Window_SetPositionSize(swigCPtr, Rectangle.getCPtr(positionSize));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // Setting Position of the window should request a relayout of the tree.
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

                _rootLayer.Dispose();
                localController.Dispose();

                foreach(var layer in _childLayers)
                {
                    layer.Dispose();
                }
                _childLayers.Clear();
            }

            this.DisconnectNativeSignals();

            base.Dispose(type);
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Window.delete_Window(swigCPtr);
        }
    }
}
