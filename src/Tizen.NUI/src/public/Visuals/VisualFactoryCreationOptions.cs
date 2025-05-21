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
    /// The hint options to determine the behavior how to create Visual at VisualFactory.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum VisualFactoryCreationOptions
    {
        /// <summary>
        /// Do not give any hint to visual creation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None,

        /// <summary>
        /// Give hint to factory that it is static image if visual type is image.
        /// It will load ImageVisual even if file extensions are animtable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ImageVisualLoadStaticImagesOnly,
    }
}
