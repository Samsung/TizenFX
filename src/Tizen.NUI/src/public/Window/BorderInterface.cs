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
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface BorderInterface
    {
        /// <summary>
        /// Create border UI. Users can override this method to draw border UI.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CreateBorderView(View rootView);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnCreated(View rootView);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnResized(int width, int height);

        public uint GetBorderLineThickness();

        public uint GetTouchThickness();

        public uint GetBorderHeight();

        public Size2D GetMinSize();

        public Size2D GetMaxSize();

        public void SetWindow(Window window);

        public Window GetWindow();

        public void Dispose();

    }
}
