/*
* Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/


namespace Tizen.Uix.Tts
{
    /// <summary>
    /// This class holds information related to the TTS SynthesizedPcm event.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class SynthesizedPcmEventArgs
    {
        internal SynthesizedPcmEventArgs(int utteranceId, SynthesizedPcmEvent pcmEvent, byte[] pcmData, AudioType pcmAudioType, int sampleRate)
        {
            UtteranceId = utteranceId;
            PcmEvent = pcmEvent;
            PcmData = pcmData;
            PcmAudioType = pcmAudioType;
            SampleRate = sampleRate;
        }

        /// <summary>
        /// The utterance ID.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int UtteranceId
        {
            get;
            internal set;
        }

        /// <summary>
        /// The event of the PCM data.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public SynthesizedPcmEvent PcmEvent
        {
            get;
            internal set;
        }

        /// <summary>
        /// The syntehsized PCM data.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public byte[] PcmData
        {
            get;
            internal set;
        }

        /// <summary>
        /// The audio type of the PCM data.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public AudioType PcmAudioType
        {
            get;
            internal set;
        }

        /// <summary>
        /// The sample rate of the PCM data.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int SampleRate
        {
            get;
            internal set;
        }
    }
}
