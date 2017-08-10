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
        ///  Class for generating Lock style notification
        /// </summary>
        public sealed class LockStyle : StyleBase
        {
            /// <summary>
            /// Gets or sets an absolute path for an image file to display on the icon of Lock style
            /// </summary>
            public string IconPath { get; set; }

            /// <summary>
            /// Gets or sets an absolute path for a thumbnail image file to display on Lock style
            /// </summary>
            public string ThumbnailPath { get; set; }

            /// <summary>
            /// Gets the key of LockStyle
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "Lock";
                }
            }

            internal override void Make(Notification notification)
            {
                LockBinder.BindObject(notification);
            }
        }
    }
}