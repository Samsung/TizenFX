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

using System;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Defines the capabilities that an AI service can support.
    /// </summary>
    [Flags]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ServiceCapabilities
    {
        /// <summary>
        /// No capabilities.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,

        /// <summary>
        /// Capability for Text-to-Speech service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TextToSpeech = 1,

        /// <summary>
        /// Capability for Speech-to-Text service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SpeechToText = 2,

        /// <summary>
        /// Capability for Large Language Model service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LargeLanguageModel = 4,

        /// <summary>
        /// Capability for Vision-related service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Vision = 8
    }

    /// <summary>
    /// Represents a generic AI service interface.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAIService
    {
        /// <summary>
        /// Gets the name of the AI service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ServiceName { get; }

        /// <summary>
        /// Gets the capabilities of the AI service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ServiceCapabilities Capabilities { get; }
    }
}
