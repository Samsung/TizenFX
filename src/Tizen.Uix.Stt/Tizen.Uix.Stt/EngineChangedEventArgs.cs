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


namespace Tizen.Uix.Stt
{
    /// <summary>
    /// This class holds information related to Engine Changed Event
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class EngineChangedEventArgs
    {
        internal EngineChangedEventArgs(string engineId, string language, bool supportSilence, bool needCredential)
        {
            this.EngineId = engineId;
            this.Language = language;
            this.SupportSilence = supportSilence;
            this.NeedCredential = needCredential;
        }

        /// <summary>
        /// Engine Id
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string EngineId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Default Language
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Language
        {
            get;
            internal set;
        }

        /// <summary>
        /// The necessity of credential
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool NeedCredential
        {
            get;
            internal set;
        }

        /// <summary>
        /// Whether the silence detection is supported or not
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool SupportSilence
        {
            get;
            internal set;
        }
    }
}
