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
    /// This class provides properties of the thumbnail of the given media
    /// </summary>
    public class ThumbnailData
    {
        internal ThumbnailData(byte[] thumbnailData, int width, int height)
        {
            Thumbnail = thumbnailData;
            Width = width;
            Height = height;
        }
        /// <summary>
        /// The thumbnail data
        /// </summary>
        public byte[] Thumbnail { get; }

        /// <summary>
        /// The width of the thumbnail
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the thumbnail
        /// </summary>
        public int Height { get; }
    }
}
