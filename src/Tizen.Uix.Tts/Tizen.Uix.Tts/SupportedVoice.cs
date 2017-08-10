/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// This class holds information about the supported voices.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SupportedVoice
    {
        internal SupportedVoice(string lang, int voiceType)
        {
            this.Language = lang;
            if (voiceType == 0)
            {
                this.VoiceType = Voice.Auto;
            }

            else if (voiceType == 1)
            {
                this.VoiceType = Voice.Male;
            }

            else if (voiceType == 2)
            {
                this.VoiceType = Voice.Female;
            }

            else if (voiceType == 3)
            {
                this.VoiceType = Voice.Child;
            }
        }

        internal SupportedVoice()
        {
            this.Language = "";
            this.VoiceType = Voice.Auto;
        }

        /// <summary>
        /// Language specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code (for example, "ko_KR" for Korean, "en_US" for American English).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Language
        {
            get;
            internal set;
        }

        public Voice VoiceType
        {
            get;
            internal set;
        }
    }
}
