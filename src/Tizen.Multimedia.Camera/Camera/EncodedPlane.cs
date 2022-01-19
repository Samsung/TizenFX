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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing the encoded image data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class EncodedPlane : IPreviewPlane
    {
        internal EncodedPlane(byte[] data, bool isDeltaFrame)
        {
            Data = data;
            IsDeltaFrame = isDeltaFrame;
        }

        /// <summary>
        /// The buffer containing the encoded image data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Data { get; }

        /// <summary>
        /// The flag indicating whether the current frame is a delta frame or not.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool IsDeltaFrame { get; }
    }
}
