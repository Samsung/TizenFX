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
    public interface IBorderInterface
    {
        /// <summary>
        /// Create border UI. User can override this method to draw border UI.
        /// </summary>
        /// <param name="rootView">The root view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CreateBorderView(View rootView);


        /// <summary>
        /// Called after the border UI is created.
        /// </summary>
        /// <param name="rootView">The root view on which the border.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnCreated(View rootView);

        /// <summary>
        /// Called when the window is resized.
        /// </summary>
        /// <param name="width">The width of the resized window</param>
        /// <param name="height">The height of the resized window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnResized(int width, int height);

        /// <summary>
        /// Returns the thickness of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetBorderLineThickness();

        /// <summary>
        /// Returns the thickness of the border's touch area.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetTouchThickness();

        /// <summary>
        /// Returns the height of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetBorderHeight();

        /// <summary>
        /// Returns the minimum size by which the window will small.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D GetMinSize();

        /// <summary>
        /// Returns the maximum size by which the window will big.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D GetMaxSize();

        /// <summary>
        /// Sets The window to which the border is added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWindow(Window window);

        /// <summary>
        /// Returns the window with borders added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window GetWindow();

        /// <summary>
        /// Returns whether overlay mode is present.
        /// If overlay mode is true, the border area is hidden when the window is maximized.
        /// And if you touched at screen, the border area is shown on the screen.
        /// Default value is false;
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOverlayMode();

        /// <summary>
        /// Dispose
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose();
    }
}
