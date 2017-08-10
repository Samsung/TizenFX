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
        ///  Class to get infomation about Notification ButtonAction.
        /// </summary>
        public class ButtonActionArgs
        {
            /// <summary>
            /// Gets the Index of the Button which is appeared at Notification.
            /// </summary>
            public ButtonIndex Index { get; internal set; }

            /// <summary>
            /// Gets the text that describes the button.
            /// </summary>
            public string Text { get; internal set; }

            /// <summary>
            /// Gets the image's path that represent the button.
            /// </summary>
            public string ImagePath { get; internal set; }

            /// <summary>
            /// Gets the AppControl that is invoked when the button is clicked.
            /// </summary>
            public AppControl Action { get; internal set; }
        }
    }
}