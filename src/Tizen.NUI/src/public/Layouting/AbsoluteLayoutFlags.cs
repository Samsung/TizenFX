/* Copyright (c) 2025 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for AbsoluteLayoutFlags.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AbsoluteLayoutFlags
    {
        /// <summary>
        /// No flags set.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the X position of the child element should be proportional to its parent.
        /// </summary>
        XProportional = 1 << 0,

        /// <summary>
        /// Indicates that the Y position of the child element should be proportional to its parent.
        /// </summary>
        YProportional = 1 << 1,

        /// <summary>
        /// Indicates that the width of the child element should be proportional to its parent.
        /// </summary>
        WidthProportional = 1 << 2,

        /// <summary>
        /// Indicates that the height of the child element should be proportional to its parent.
        /// </summary>
        HeightProportional = 1 << 3,

        /// <summary>
        /// Indicates that both the X and Y positions of the child element should be proportional to its parent.
        /// </summary>
        PositionProportional = 1 | 1 << 1,

        /// <summary>
        /// Indicates that both the width and height of the child element should be proportional to its parent.
        /// </summary>
        SizeProportional = 1 << 2 | 1 << 3,

        /// <summary>
        /// Indicates that all properties of the child element should be proportional to its parent.
        /// </summary>
        All = ~0
    }
}