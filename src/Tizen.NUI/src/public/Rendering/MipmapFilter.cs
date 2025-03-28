// Copyright (c) 2025 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Specifies the mipmap filtering metho
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MipmapFilter
    {
        /// <summary>
        /// No mipmap usage
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None,

        /// <summary>
        /// Uses the nearest mipmap level
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Nearest,

        /// <summary>
        /// Uses liniear interpolation between mipmap levels
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Linear
    }
}