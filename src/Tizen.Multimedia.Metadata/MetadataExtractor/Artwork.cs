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
    /// Represents the artwork information of the media.
    /// </summary>
    public class Artwork
    {
        /// <summary>
        /// Initializes a new instance of the Artwork class with the specified data and the mime type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="data">The data of the artwork to set the metadata.</param>
        /// <param name="mimeType">The mime type of the data of the artwork.</param>
        public Artwork(byte[] data, string mimeType)
        {
            Data = data;
            MimeType = mimeType;
        }

        /// <summary>
        /// Gets the encoded artwork image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Data { get; }

        /// <summary>
        /// Gets the mime type of the artwork.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MimeType { get; }
    }
}
