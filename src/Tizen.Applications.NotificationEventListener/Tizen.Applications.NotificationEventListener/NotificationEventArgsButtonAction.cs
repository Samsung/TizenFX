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
    public partial class NotificationEventArgs
    {
        /// <summary>
        ///  Structure to encapsulate Notification ButtonAction.
        ///  You can get an Text, ImagePath, Action to be invoked when the button is click by the user.
        /// </summary>
        public class ButtonActionArgs
        {
            /// <summary>
            /// Gets the Index of the Button which is appeared at Notification.
            /// </summary>
            /// <example>
            /// <code>
            /// int index = NotificationEventArgs.ButtonActionArgs.Index;
            /// </code>
            /// </example>
            public int Index { get; internal set; }

            /// <summary>
            /// Gets the text that describes the button.
            /// </summary>
            /// <value>
            /// Default value is null.
            /// </value>
            /// <example>
            /// <code>
            /// string text = NotificationEventArgs.ButtonActionArgs.Text;
            /// </code>
            /// </example>
            public string Text { get; internal set; }

            /// <summary>
            /// Gets the image's path that represent the button.
            /// </summary>
            /// <value>
            /// Default value is null.
            /// </value>
            /// <example>
            /// <code>
            /// string imagePath = NotificationEventArgs.ButtonActionArgs.ImagePath;
            /// </code>
            /// </example>
            public string ImagePath { get; internal set; }

            /// <summary>
            /// Gets the AppControl that is invoked when the button is clicked.
            /// </summary>
            /// <value>
            /// Default value is null.
            /// </value>
            /// <example>
            /// <code>
            /// AppControl action = NotificationEventArgs.ButtonActionArgs.Action;
            /// </code>
            /// </example>
            public AppControl Action { get; internal set; }
        }
    }
}