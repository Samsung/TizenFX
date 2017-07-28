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
    /// The class contains common properties and methods of notifications.
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    public sealed partial class Notification
    {
        /// <summary>
        ///  Class for generating indicator style notification.
        /// </summary>
        public sealed class IndicatorStyle : StyleBase
        {
            /// <summary>
            /// Gets or sets an absolute path for an image file.
            /// If you set IconPath, you can see the icon on the right side of indicator.
            /// </summary>
            public string IconPath { get; set; }

            /// <summary>
            /// Gets or sets a sub text for displaying indicator style.
            /// </summary>
            public string SubText { get; set; }

            /// <summary>
            /// Gets the key of IndicatorStyle.
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "Indicator";
                }
            }

            internal override void Make(Notification notification)
            {
                IndicatorBinder.BindObject(notification);
            }
        }
    }
}
