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

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Enumeration for the states.
    /// </summary>
    public enum AudioPlayerState
    {
        /// <summary>
        ///  Fail state.
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Ready state.
        /// </summary>
        Ready = 0,

        /// <summary>
        /// Playing state.
        /// </summary>
        Playing = 3,

        /// <summary>
        /// Paused state.
        /// </summary>
        Paused = 4,

        /// <summary>
        /// Stopped state.
        /// </summary>
        Stopped = 5,

        /// <summary>
        /// Finished state.
        /// </summary>
        Finished = 6,

        /// <summary>
        /// Unavailable state.
        /// </summary>
        Unavailable
    };
}
