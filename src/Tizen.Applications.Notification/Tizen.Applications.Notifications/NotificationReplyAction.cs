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
        ///  Class for displaying direct-reply at notification.
        ///  You must set a ReplyMax and Button. Otherwise user can't send written text to application which is set by AppControl.
        /// </summary>
        public sealed class ReplyAction : MakerBase
        {
            /// <summary>
            /// Gets or sets the Index of Button which is appeared at Notification.
            /// If you set ParentIndex, ReplyAction is displayed when button matched with ParentIndex click by the user.
            /// If you don't set ParentIndex, appeared to notification directly.
            /// </summary>
            public ButtonIndex ParentIndex { get; set; } = ButtonIndex.None;

            /// <summary>
            /// Gets or sets the PlaceHolderText of ReplyAction which is appeared at Notification.
            /// If you set PlaceHolderText, it is displayed to placeholder in notification.
            /// </summary>
            public string PlaceHolderText { get; set; }

            /// <summary>
            /// Gets or sets the ReplyMax of ReplyAction which is appeared at Notification.
            /// You must set a ReplyMax. Otherwise user don't write text to placeholder in notification.
            /// </summary>
            /// <value>
            /// Default value is 160.
            /// </value>
            public int ReplyMax { get; set; } = 160;

            /// <summary>
            /// Gets or sets the Button which is appeared to ReplyAction in Notification.
            /// You must set a Button. Otherwise user can't send written text to application which is set by AppControl.
            /// </summary>
            /// <remarks>
            /// If you set it to null, the already set ButtonAction will be removed.
            /// </remarks>
            /// <example>
            /// <code>
            /// ReplyAction button = new ReplyAction
            /// {
            ///     ParentIndex = ButtonIndex.Second;
            ///     PlaceHolderText = "Please write your reply."
            ///     ReplyMax = 160,
            ///     Button = new ButtonAction
            ///     {
            ///         text = "Yes",
            ///         ImagePath = "image path",
            ///         Action = new AppControl{ ApplicationId = "org.tizen.app" };
            ///     };
            /// };
            /// </code>
            /// </example>
            public ButtonAction Button { get; set; }

            internal override void Make(Notification notification)
            {
                string replyKey = "__PARENT_INDEX__";

                if (Button != null)
                {
                    Interop.Notification.SetText(notification.Handle, NotificationText.InputButton, Button.Text, null, -1);
                    Interop.Notification.SetImage(notification.Handle, NotificationImage.TextInputButton, Button.ImagePath);

                    if (this.Button.Action != null && this.Button.Action.SafeAppControlHandle.IsInvalid == false)
                    {
                        Interop.Notification.SetEventHandler(notification.Handle, (int)NotificationEventType.ClickOnTextInputButton, this.Button.Action.SafeAppControlHandle);

                        if (this.ParentIndex != ButtonIndex.None)
                        {
                            Interop.Notification.SetEventHandler(notification.Handle, (int)this.ParentIndex, this.Button.Action.SafeAppControlHandle);
                        }
                    }
                }

                Bundle bundle = new Bundle();
                bundle.AddItem(replyKey, ((int)this.ParentIndex).ToString());
                Interop.Notification.SetExtentionData(notification.Handle, replyKey, bundle.SafeBundleHandle);

                Interop.Notification.SetPlaceHolderLength(notification.Handle, this.ReplyMax);
                Interop.Notification.SetText(notification.Handle, NotificationText.PlaceHolder, PlaceHolderText, null, -1);
            }
        }
    }
}
