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
    using System.Collections.Generic;

    /// <summary>
    /// This class provides methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs
    {
        /// <summary>
        /// Class to get infomation about notification active style.
        /// </summary>
        public class ActiveStyleArgs : StyleArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ActiveStyleArgs"/> class.
            /// </summary>
            public ActiveStyleArgs()
            {
                Button = new List<ButtonActionArgs>();
            }

            /// <summary>
            /// Gets the IsAutoRemove option of the active notification.
            /// IsAutoRemove option lets the active notification be removed several seconds after it shows.
            /// </summary>
            /// <value>
            /// When 'IsAutoRemove' is set as false, the active notification will not be removed as long as the user removes
            /// the active notification, or the app which posted the active notification removes the active notification.
            /// </value>
            public bool IsAutoRemove { get; internal set; }

            /// <summary>
            /// Gets an absolute path for an image file to display on the background of active notification.
            /// </summary>
            public string BackgroundImage { get; internal set; }

            /// <summary>
            /// Gets the default button to display highlight on the active notification.
            /// </summary>
            public ButtonIndex DefaultButton { get; internal set; }

            /// <summary>
            /// Gets timeout value in seconds when the notification can be hidden from the viewer.
            /// </summary>
            public int HideTimeout { get; internal set; }

            /// <summary>
            /// Gets timeout value in seconds when the notification can be deleted from the viewer.
            /// </summary>
            public int DeleteTimeout { get; internal set; }

            /// <summary>
            /// Gets Action which is invoked when notification is hidden by user.
            /// </summary>
            /// <remarks>
            /// The property is only reflected on Tizen TV.
            /// If you use this API on other profile, this action have no effect
            /// </remarks>
            public AppControl HiddenByUserAction { get; internal set; }

            /// <summary>
            /// Gets or sets Action which is invoked when there is no any response by user until hide timeout.
            /// </summary>
            /// <remarks>
            /// The property is only reflected on Tizen TV.
            /// If you use this API on other profile, this action settings have no effect
            /// </remarks>
            public AppControl HiddenByTimeoutAction { get; internal set; }

            /// <summary>
            /// Gets or sets Action which is invoked when the notification is hidden by external factor.
            /// </summary>
            /// <remarks>
            /// If you use this API on other profile, this action settings have no effect
            /// </remarks>
            public AppControl HiddenByExternalAction { get; internal set; }

            /// <summary>
            /// Gets a button to this active notification style.
            /// Buttons are displayed in the notification content.
            /// </summary>
            public IList<ButtonActionArgs> Button { get; internal set; }

            /// <summary>
            /// Gets a ReplyAction to this active notification style.
            /// </summary>
            public ReplyActionArgs Reply { get; internal set; }

            internal override string Key
            {
                get
                {
                    return "Active";
                }
            }
        }
    }
}
