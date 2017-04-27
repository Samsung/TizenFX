/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEventListener
{
    /// <summary>
    /// This class provides the methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs
    {
        /// <summary>
        ///  Class to generate the BigPicture style notification
        /// </summary>
        public class BigPictureStyleArgs : StyleArgs
        {
            /// <summary>
            /// Gets the path of the image file to display on the image of BigPicture style.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.BigPictureStyleArgs style = NotificationEventArgs.GetStyle<NotificationEventArgs.BigPictureStyleArgs>();
            /// string imagePath = style.ImagePath;
            /// </code>
            /// </example>
            public string ImagePath { get; internal set; }

            /// <summary>
            /// Gets the size image to display on the image of BigPicture style.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.BigPictureStyleArgs style = NotificationEventArgs.GetStyle<NotificationEventArgs.BigPictureStyleArgs>();
            /// int imagesize = imagePath = style.ImageSize;
            /// </code>
            /// </example>
            public int ImageSize { get; internal set; }

            /// <summary>
            /// Gets the content to display BigPicture style.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.BigPictureStyleArgs style = NotificationEventArgs.GetStyle<NotificationEventArgs.BigPictureStyleArgs>();
            /// string content = imagePath = style.Content;
            /// </code>
            /// </example>
            public string Content { get; internal set; }

            internal override string Key
            {
                get
                {
                    return "BigPicture";
                }
            }
        }
    }
}
