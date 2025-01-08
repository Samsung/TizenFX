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

namespace Tizen.AIAvatar
{
    /// <summary>
    /// VoiceType is an enum that represents various types of voices.  
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum VoiceType
    {
        /// <summary>
        /// Automatically determines the best voice to use based on available options.  
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Auto = 0,
        /// <summary>
        /// Selects a male voice for speech synthesis.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Male = 1,
        /// <summary>
        /// Selects a female voice for speech synthesis.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Female = 2,
        /// <summary>
        /// Selects a child's voice for speech synthesis.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Child = 3
    }
}
