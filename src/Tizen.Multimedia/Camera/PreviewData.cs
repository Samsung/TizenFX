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
    /// The class containing preview image data.
    /// </summary>
    public class PreviewData
    {
        internal PreviewData()
        {
        }

        /// <summary>
        /// The pixel format of the image.
        /// </summary>
        public CameraPixelFormat Format
        {
            get;
            internal set;
        }

        /// <summary>
        /// The width of the image.
        /// </summary>
        public int Width
        {
            get;
            internal set;
        }

        /// <summary>
        /// The height of the image.
        /// </summary>
        public int Height
        {
            get;
            internal set;
        }

        /// <summary>
        /// The time of capture of the image.
        /// </summary>
        public uint TimeStamp
        {
            get;
            internal set;
        }
    }
}

