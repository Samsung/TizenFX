/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// MaterialAlphaModeType is enum for Material's AlphaMode type
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MaterialAlphaModeType
    {
        /// <summary>
        /// This indicates that the material is fully opaque and that the alpha value should be ignored.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Opaque,

        /// <summary>
        /// This indicates that the material is either fully opaque or fully transparent depending on the alpha value. The alpha value is used to mask out areas of the material that should be transparent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Mask,

        /// <summary>
        /// This indicates that the material is transparent and that the alpha value should be used to blend the material with the background.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Blend,
    }
}
