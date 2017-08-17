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
    /// This class provides the information related to STT engine.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SupportedEngine
    {
        private string _engineId;
        private string _engineName;

        internal SupportedEngine(string id, string name)
        {
            this._engineId = id;
            this._engineName = name;
        }
        /// <summary>
        /// The engine ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The string engine ID.
        /// </returns>
        public string EngineId
        {
            get
            {
                return _engineId;
            }
        }

        /// <summary>
        /// The engine name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The string engine name.
        /// </returns>
        public string EngineName
        {
            get
            {
                return _engineName;
            }
        }
    }
}
