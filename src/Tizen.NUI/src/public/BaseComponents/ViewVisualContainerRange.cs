/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Range of visual for the container.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ViewVisualContainerRange
    {
        /// <summary>
        /// Invalid enum.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Invalid = -1,

        /// <summary>
        /// Visual will be rendered under the shadow.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Shadow,

        /// <summary>
        /// Visual will be rendered under the background.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Background,

        /// <summary>
        /// Visual will be rendered under the content.
        /// It is default value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Content,

        /// <summary>
        /// Visual will be rendered under the decoration.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Decoration,

        /// <summary>
        /// Visual will be rendered above the foreground effect.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ForegroundEffect,
    };
}
