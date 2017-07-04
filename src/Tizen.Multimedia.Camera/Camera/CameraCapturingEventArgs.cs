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

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class which contains details about the captured image.
    /// </summary>
    public class CameraCapturingEventArgs : EventArgs
    {
        internal CameraCapturingEventArgs(ImageData img, ImageData post, ImageData thumbnail)
        {
            Image = img;
            PostView = post;
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// The image data of the captured picture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageData Image { get; }

        /// <summary>
        /// The image data of the postview.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageData PostView { get; }

        /// <summary>
        /// The image data of the thumbnail.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageData Thumbnail { get; }
    }
}

