/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// An abstract class to represent payload.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class Payload
    {
        private readonly string LogTag = "Tizen.Cion";
        internal PayloadSafeHandle _handle;

        /// <summary>
        /// Gets type of the payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public abstract PayloadType PayloadType { get; }

        /// <summary>
        /// Gets Id of the payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Id
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionPayload.CionPayloadGetPayloadID(_handle, out string id);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get id of payload.");
                    return "";
                }
                return id;
            }            
        }
    }
}
