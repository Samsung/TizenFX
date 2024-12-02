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

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Defines the capabilities that an AI service can support.
    /// </summary>
    [Flags]
    public enum ServiceCapabilities
    {
        /// <summary>
        /// No capabilities.
        /// </summary>
        None = 0,

        /// <summary>
        /// Capability for Text-to-Speech service.
        /// </summary>
        TextToSpeech = 1,

        /// <summary>
        /// Capability for Speech-to-Text service.
        /// </summary>
        SpeechToText = 2,

        /// <summary>
        /// Capability for Large Language Model service.
        /// </summary>
        LargeLanguageModel = 4,

        /// <summary>
        /// Capability for Vision-related service.
        /// </summary>
        Vision = 8
    }

    /// <summary>
    /// Represents a generic AI service interface.
    /// </summary>
    public interface IAIService
    {
        /// <summary>
        /// Gets the name of the AI service.
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// Gets the capabilities of the AI service.
        /// </summary>
        ServiceCapabilities Capabilities { get; }
    }
}
