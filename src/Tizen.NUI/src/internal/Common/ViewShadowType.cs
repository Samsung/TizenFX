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

namespace Tizen.NUI
{
    /// <summary>
    /// Specifies the type of shadow that can be applied to a view.
    /// This enumeration is used internally to differentiate between outer and inner shadow effects
    /// when adding a shadow visual to a view.
    /// </summary>
    internal enum ViewShadowType
    {
        /// <summary>
        /// Represents an outer shadow.
        /// An outer shadow is a visual effect that is drawn outside the boundaries of a view,
        /// typically to create a sense of depth or elevation, as if the view is raised above the surface.
        /// </summary>
        BoxShadow,

        /// <summary>
        /// Represents an inner shadow.
        /// An inner shadow is a visual effect that is drawn inside the boundaries of a view,
        /// typically to create a sense of depression or inset, as if the view is pressed into the surface.
        /// </summary>
        InnerShadow
    }
}
