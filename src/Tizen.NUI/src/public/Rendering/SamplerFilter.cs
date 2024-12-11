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
    /// Specifies the sampling filter method
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SamplerFilter
    {
        /// <summary>
        /// Uses the nearest texture sample
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Nearest,

        /// <summary>
        /// Uses linear interpolation between texture samples
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Linear,
    }
}