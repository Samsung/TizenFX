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
 *
 */

using System.ComponentModel;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Enumeration for the states.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AnimatorState
    {
        /// <summary>
        ///  Fail state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Failed = -1,

        /// <summary>
        /// Ready state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Ready = 0,

        /// <summary>
        /// Playing state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Playing = 3,

        /// <summary>
        /// Paused state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Paused = 4,

        /// <summary>
        /// Stopped state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Stopped = 5,

        /// <summary>
        /// AnimationFinished state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AnimationFinished = 6,

        /// <summary>
        /// Unavailable state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Unavailable
    };
}
