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

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class containing common properties and methods of Notifications
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    public sealed partial class Notification
    {
        /// <summary>
        ///  Class for generating BigPicture style notification
        /// </summary>
        public sealed class BigPictureStyle : StyleBase
        {
            /// <summary>
            /// Gets or sets the absolute path for a big picture image file to display on BigPicture style of the notification.
            /// </summary>
            public string ImagePath { get; set; }

            /// <summary>
            /// Gets or sets the absolute path for a big picture image size to display on BigPicture style of the notification.
            /// </summary>
            /// <value>
            /// This value is only height size.
            /// </value>>
            public int ImageSize { get; set; }

            /// <summary>
            /// Gets or sets the content text to display on BigPicture style of the notification.
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// Gets the key of BigPictureStyle
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "BigPicture";
                }
            }

            internal override void Make(Notification notification)
            {
                BigPictureBinder.BindObject(notification);
            }
        }
    }
}