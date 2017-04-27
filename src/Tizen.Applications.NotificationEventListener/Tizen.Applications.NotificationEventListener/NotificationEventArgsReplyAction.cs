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
        ///  Class to display the direct reply on the active notification.
        /// </summary>
        public class ReplyActionArgs
        {
            /// <summary>
            /// Gets Index of Button which is appeared at Notification.
            /// If there is no ParentIndex, the ReplyAction should be displayed directly on the active notification.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.ActiveStyleArgs style = args.GetStyle<NotificationEventArgs.ActiveStyleArgs>();
            /// NotificationEventArgs.ReplyActionArgs action = style.Reply;
            /// ButtonIndex buttonIndex = action.ParentIndex;
            /// </code>
            /// </example>
            public ButtonIndex ParentIndex { get; internal set; } = ButtonIndex.None;

            /// <summary>
            /// Gets the PlaceHolderText of ReplyAction which is appeared at Notification.
            /// It will be displayed to the text input box on the active notification.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.ActiveStyleArgs style = args.GetStyle<NotificationEventArgs.ActiveStyleArgs>();
            /// NotificationEventArgs.ReplyActionArgs action = style.Reply;
            /// string placeholderText = action.PlaceHolderText;
            /// </code>
            /// </example>
            public string PlaceHolderText { get; internal set; }

            /// <summary>
            /// Gets a max length of text input.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.ActiveStyleArgs style = args.GetStyle<NotificationEventArgs.ActiveStyleArgs>();
            /// NotificationEventArgs.ReplyActionArgs action = style.Reply;
            /// int replyMax = action.ReplyMax;
            /// </code>
            /// </example>
            public int ReplyMax { get; internal set; }

            /// <summary>
            /// Gets the button displayed in the replyaction.
            /// </summary>
            /// <example>
            /// <code>
            /// NotificationEventArgs.ActiveStyleArgs style = args.GetStyle<NotificationEventArgs.ActiveStyleArgs>();
            /// NotificationEventArgs.ReplyActionArgs action = style.Reply;
            /// ButtonActionArgs button = action.Button;
            /// </code>
            /// </example>
            public ButtonActionArgs Button { get; internal set; }
        }
    }
}