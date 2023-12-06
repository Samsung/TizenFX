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
    /// Depth index ranges to define rendering order.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MaterialDepthIndexRange
    {
        /// <summary>
        /// Depth index range for 3D scene content.
        /// </summary>
        /// <remarks>
        /// The range of the scene content is between [Scene, Scene + 999]
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        Scene = -2000,

        /// <summary>
        /// Depth index range for UI scene content.
        /// </summary>
        /// <remarks>
        /// The range of the UI content is between [UI, UI + 999].
        /// Some of internally created Renderer of Toolkit::Control already has
        /// default depth index value.
        /// Developer can fix the default values for their design.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        UI = 0,
    }
}
