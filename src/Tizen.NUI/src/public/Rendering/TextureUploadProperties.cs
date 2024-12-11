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

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Structure to define properties for texture upload
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct TextureUploadProperties
    {
        /// <summary>
        /// The layer of a cube map or array texture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint layer;

        /// <summary>
        /// The level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint mipmap;

        /// <summary>
        /// The horizontal offset of the rectangular area in the texture that will be updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint xOffset;

        /// <summary>
        /// The vertical offset of the rectangular area in the texture that will be updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint yOffset;

        /// <summary>
        /// The width of the rectangular area in the texture that will be updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint width;

        /// <summary>
        /// height of the rectangular area in the texture that will be updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint height;
    }
}
