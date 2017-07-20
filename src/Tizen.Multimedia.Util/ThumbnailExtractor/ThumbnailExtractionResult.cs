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
    /// Represents the result of thumbnail extraction.
    /// </summary>
    public class ThumbnailExtractionResult
    {
        internal ThumbnailExtractionResult(byte[] thumbnailData, int width, int height)
        {
            RawData = thumbnailData;
            Size = new Size(width, height);
        }

        /// <summary>
        /// The thumbnail data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] RawData { get; }

        /// <summary>
        /// The size of the thumbnail.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size Size { get; }
    }
}
