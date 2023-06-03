/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This is the interface used to draw the border UI.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBorderInterface : IDisposable
    {
        /// <summary>
        /// The thickness of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BorderLineThickness {get;}

        /// <summary>
        /// The thickness of the border's touch area.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TouchThickness {get;}

        /// <summary>
        /// The height of the border.
        /// This value is the initial value used when creating borders.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderHeight {get;}

        /// <summary>
        /// The minimum size by which the window will small.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinSize {get;}

        /// <summary>
        /// The maximum size by which the window will big.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MaxSize {get;}

        /// <summary>
        /// The window with borders added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window BorderWindow {get; set;}

        /// <summary>
        /// Whether overlay mode.
        /// If overlay mode is true, the border area is hidden when the window is maximized.
        /// And if you touched at screen, the border area is shown on the screen.
        /// Default value is false;
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OverlayMode {get;}

        /// <summary>
        /// Set the window resizing policy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window.BorderResizePolicyType ResizePolicy {get;}

        /// <summary>
        /// Create top border UI. User can override this method to draw top border UI.
        /// </summary>
        /// <param name="topView">The top view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CreateTopBorderView(View topView);

        /// <summary>
        /// Create bottom border UI. User can override this method to draw bottom border UI.
        /// </summary>
        /// <param name="bottomView">The bottom view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CreateBottomBorderView(View bottomView);

        /// <summary>
        /// Create border UI. User can override this method to draw border UI.
        /// A top border and a bottom border are added to this view.
        /// </summary>
        /// <param name="borderView">The border view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CreateBorderView(View borderView);

        /// <summary>
        /// Called after the border UI is created.
        /// </summary>
        /// <param name="borderView">The border view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnCreated(View borderView);

        /// <summary>
        /// Called when the window is resized.
        /// </summary>
        /// <param name="width">The width of the resized window</param>
        /// <param name="height">The height of the resized window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnResized(int width, int height);

        /// <summary>
        /// Called when the window is moved.
        /// </summary>
        /// <param name="x">The x of the moved window</param>
        /// <param name="y">The y of the moved window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnMoved(int x, int y);

        /// <summary>
        /// Called when window has been moved the display server.
        /// </summary>
        /// <param name="x">The x of the has been moved window</param>
        /// <param name="y">The y of the has been moved window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnMoveCompleted(int x, int y);

        /// <summary>
        /// Called when window has been resized the display server.
        /// </summary>
        /// <param name="width">The width of the resized window</param>
        /// <param name="height">The height of the resized window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnResizeCompleted(int width, int height);

        /// <summary>
        /// Called when the window is maximized.
        /// </summary>
        /// <param name="isMaximized">If window is maximized or unmaximized.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnMaximize(bool isMaximized);

        /// <summary>
        /// Called when the window is minimized.
        /// </summary>
        /// <param name="isMinimized">If window is minimized or unminimized.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnMinimize(bool isMinimized);

        /// <summary>
        /// Called when there is a change in overlay mode.
        /// </summary>
        /// <param name="enabled">If true, borderView has entered overlayMode.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnOverlayMode(bool enabled);

    }
}
