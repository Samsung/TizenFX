/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
	using System.ComponentModel;

    /// <summary>
    /// This class contains common properties and methods of notifications.
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    public sealed partial class Notification
    {
        /// <summary>
        /// Class for generating extension style notification.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
		[EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class ExtensionStyle : StyleBase
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsActive { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public string ExtensionImagePath { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ExtensionImageSize { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsThumbnail { get; set; } = false;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public string ThumbnailImagePath { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AppControl ThumbnailAction { get; set; }

            /// <summary>
            /// Gets the key of Extension.
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "Extension";
                }
            }

            internal override void Make(Notification notification)
            {
                ExtensionBinder.BindObject(notification);
            }
        }
    }
}