/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
 */

using System.ComponentModel;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Represents an interface for custom motion data operations.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICustomMotionData
    {
        /// <summary>
        /// Initializes the instance of the custom motion data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Initialize();

        /// <summary>
        /// Retrieves motion data based on the specified duration in milliseconds.
        /// </summary>
        /// <param name="durationMilliseconds">The duration in milliseconds for which to retrieve motion data.</param>
        /// <returns>An instance of MotionData representing the motion data for the given duration.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionData GetMotionData(int durationMilliseconds);
    }
}
