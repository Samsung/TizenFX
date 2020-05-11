/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
// using System;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
// using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary></summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ScrollBarBase : Control
    {
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarBase() : base()
        {
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarBase(string style) : base(style)
        {
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarBase(ControlStyle style) : base(style)
        {
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract View GetView();

        // /// <summary></summary>
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // abstract void Initialize(ScrollableBase.Direction direction, uint contentLength, uint visibleLength, uint currentPosition = 0);

        // /// <summary></summary>
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // abstract void UpdateContentLength(uint contentLength, uint currentPosition, uint? speed = null);

        // /// <summary></summary>
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // abstract void GoTo(uint position, uint? speed = null);
    }
}