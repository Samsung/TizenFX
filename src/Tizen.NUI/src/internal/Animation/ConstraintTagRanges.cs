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

using global::System;
using global::System.ComponentModel;
using global::System.Runtime.InteropServices;
namespace Tizen.NUI
{
    /// <summary>
    /// Determinate the range of constraint tag
    /// </summary>
    internal sealed class ConstraintTagRanges
    {
        /// <summary>
        /// Default tag of constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly uint Default = 0;

        /// <summary>
        /// Minimum number of tag we can use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly uint TagMin = 1;

        /// <summary>
        /// Maximum number of tag we can use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly uint TagMax = 999999999;
    }
}
