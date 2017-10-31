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
    /// Provides data for the <see cref="Camera.Capturing"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraCapturingEventArgs : EventArgs
    {
        internal CameraCapturingEventArgs(StillImage main, StillImage post, StillImage thumbnail)
        {
            MainImage = main;
            PostView = post;
            Thumbnail = thumbnail;
        }

        /// <summary>
        /// Gets the main image data of the captured still image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public StillImage MainImage { get; }

        /// <summary>
        /// Gets the image data of the post view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StillImage PostView { get; }

        /// <summary>
        /// Gets the image data of the thumbnail.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StillImage Thumbnail { get; }
    }
}
