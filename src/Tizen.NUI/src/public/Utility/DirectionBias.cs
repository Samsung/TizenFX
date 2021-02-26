/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    /// The Direction Bias type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1712: Do not prefix enum values with type name")]
    public enum DirectionBias
    {
        /// <summary>
        /// Bias scroll snap to Left.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DirectionBiasLeft = -1,
        /// <summary>
        /// Don't bias scroll snap.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DirectionBiasNone = 0,
        /// <summary>
        /// Bias scroll snap to Right.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DirectionBiasRight = 1
    }
}
