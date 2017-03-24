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
        ///  Class to help you set button on Active style of Notification
        /// </summary>
        /// <remarks>
        /// It must include a Text, an Index, an ImagePath, and an Action to be invoked when user select the button.
        /// </remarks>>
        public sealed class ButtonAction : MakerBase
        {
            /// <summary>
            /// Gets or sets the index of Button which is appeared at Notification.
            /// </summary>
            public ButtonIndex Index { get; set; } = ButtonIndex.None;

            /// <summary>
            /// Gets or sets the text describing the button
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// Gets or sets the image path that represent the button
            /// </summary>
            public string ImagePath { get; set; }

            /// <summary>
            /// Gets or sets the action which is invoked when button is clicked
            /// </summary>
            /// <value>
            /// If you don't set Action, nothing happens when button is clicked.
            /// </value>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            /// <example>
            /// <code>
            /// ButtonAction button = new ButtonAction
            /// {
            ///     Index = ButtonIndex.First,
            ///     text = "Yes",
            ///     ImagePath = "image path",
            ///     Action = new AppControl{ ApplicationId = "org.tizen.app" };
            /// };
            /// </code>
            /// </example>
            /// <seealso cref="Tizen.Applications.AppControl"></seealso>
            public AppControl Action { get; set; }

            internal override void Make(Notification notification)
            {
                int enumIndex = (int)NotificationText.FirstButton + (int)Index;

                Interop.Notification.SetText(notification.Handle, (NotificationText)enumIndex, Text, null, -1);
                enumIndex = (int)NotificationImage.FirstButton + (int)Index;
                Interop.Notification.SetImage(notification.Handle, (NotificationImage)enumIndex, ImagePath);
                if (Action != null && Action.SafeAppControlHandle.IsInvalid == false)
                {
                    Interop.Notification.SetEventHandler(notification.Handle, (int)Index, Action.SafeAppControlHandle);
                }
            }
        }
    }
}
