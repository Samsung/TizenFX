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
using System.Collections.Generic;


namespace Tizen.AIAvatar
{
    /// <summary>
    /// Provides data for LLM response events.
    /// </summary>
    public class llmResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the task ID associated with the LLM response.
        /// </summary>
        public int TaskID { get; set; }

        /// <summary>
        /// Gets or sets the response text from the LLM.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the error message, if any, from the LLM response.
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// Provides data for TTS streaming events.
    /// </summary>
    public class ttsStreamingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the audio data of the current chunk.
        /// </summary>
        public byte[] AudioData { get; set; }

        /// <summary>
        /// Gets or sets the sample rate of the audio data.
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        /// Gets or sets the text being converted to speech.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the voice used for the TTS conversion.
        /// </summary>
        public string Voice { get; set; }

        /// <summary>
        /// Gets or sets the size of the current audio data chunk in bytes.
        /// </summary>
        public int AudioBytes { get; set; }

        /// <summary>
        /// Gets or sets the total number of bytes for the audio data.
        /// </summary>
        public int TotalBytes { get; set; }

        /// <summary>
        /// Gets or sets the number of bytes processed so far.
        /// </summary>
        public int ProcessedBytes { get; set; }

        /// <summary>
        /// Gets or sets the progress percentage of the TTS processing.
        /// </summary>
        public double ProgressPercentage { get; set; }

        /// <summary>
        /// Gets or sets the error message, if any, during the TTS process.
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// Provides data for STT streaming events.
    /// </summary>
    public class sttStreamingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether the text is interim.
        /// </summary>
        public bool Interim { get; set; }

        /// <summary>
        /// Gets or sets the transcribed text from the STT process.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the error message, if any, during the STT process.
        /// </summary>
        public string Error { get; set; }
    }

    /// <summary>
    /// Represents service endpoints for AI services.
    /// </summary>
    public class ServiceEndpoints
    {
        /// <summary>
        /// Gets or sets the endpoint for the LLM service.
        /// </summary>
        public string LLMEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for the Text-to-Speech service.
        /// </summary>
        public string TextToSpeechEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for the Speech-to-Text service.
        /// </summary>
        public string SpeechToTextEndpoint { get; set; }
    }

    /// <summary>
    /// Represents the configuration for an AI service.
    /// </summary>
    public abstract class AIServiceConfiguration
    {
        /// <summary>
        /// Gets or sets the API key for the AI service.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the service endpoints.
        /// </summary>
        public ServiceEndpoints Endpoints { get; set; }

        /// <summary>
        /// Gets or sets additional settings for the AI service.
        /// </summary>
        public Dictionary<string, object> AdditionalSettings { get; set; } = new();
    }
}
