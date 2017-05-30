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
    using System.Collections.Generic;

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
        ///  Class for generating Active style notification
        /// </summary>
        public sealed class ActiveStyle : StyleBase
        {
            private IDictionary<ButtonIndex, ButtonAction> buttonDictionary;
            private int hideTimeout = 0;
            private int deleteTimeout = 0;

            /// <summary>
            /// Initializes a new instance of the <see cref="ActiveStyle"/> class.
            /// </summary>
            public ActiveStyle()
            {
                buttonDictionary = new Dictionary<ButtonIndex, ButtonAction>();
            }

            /// <summary>
            /// Gets or sets an absolute path for an image file to display on the background of active notification
            /// </summary>
            public string BackgroundImage { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the active notification is removed automatically. Default value is true.
            /// </summary>
            /// <remarks>
            /// IsAutoRemove option lets the active notification be removed several seconds after it shows.
            /// When 'IsAutoRemove' is set as false, the active notification will not be removed as long as the user removes
            /// the active notification or the app which posted the active notification removes the active notification.
            /// </remarks>>
            public bool IsAutoRemove { get; set; } = true;

            /// <summary>
            /// Gets or sets the default button to display highlight on the active notification
            /// </summary>
            /// <remarks>
            /// The default button for display highlight is only reflected on Tizen TV.
            /// If you use this Property on other profile, this value have no effect
            /// </remarks>
            public ButtonIndex DefaultButton { get; set; } = ButtonIndex.None;

            /// <summary>
            /// Gets or sets a ReplyAction to this active notification style.
            /// </summary>
            /// <remarks>
            /// When you add a ReplyAction to the ActiveStyle, the notification UI will show a ReplyAction with button.
            /// If you set null parameter, ReplyAction is disappeared.
            /// </remarks>
            /// <example>
            /// <code>
            ///
            /// ButtonAction button = new ButtonAction
            /// {
            ///     Index = ButtonIndex.First,
            ///     Text = "Yes"
            ///     Action = new AppControl{ ApplicationId = "org.tizen.app" };
            /// };
            ///
            /// ReplyAction reply = new ReplyAction
            /// {
            ///     ParentIndex = ButtonIndex.First;
            ///     PlaceHolderText = "Please write your reply."
            ///     ReplyMax = 160,
            ///     Button = new ButtonAction
            ///     {
            ///         Text = "Yes",
            ///         ImagePath = "image path"
            ///         Action = new AppControl{ ApplicationId = "org.tizen.app" };
            ///     };
            /// };
            ///
            /// ActiveStyle active = new ActiveStyle
            /// {
            ///     AutoRemove = true,
            ///     BackgroundImage = "image path",
            ///     ReplyAction = reply
            /// };
            ///
            /// active.AddButtonAction(button);
            /// </code>
            /// </example>
            public ReplyAction ReplyAction { get; set; }

            /// <summary>
            /// Gets the key of ActiveStyle
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "Active";
                }
            }

            /// <summary>
            /// Method to set times to hide or delete notification.
            /// </summary>
            /// <remarks>
            /// The time settings for hiding and deleting are only reflected on Tizen TV.
            /// If you use this API on other profile, this time settings have no effect
            /// </remarks>
            /// <param name="hideTime">The value in second when the notification can be hidden from the notification viewer after notification is posted</param>
            /// <param name="deleteTime">The value in second when the notification can be deleted from the notification list in setting application after notification is posted</param>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            public void SetRemoveTime(int hideTime, int deleteTime)
            {
                if (hideTime < 0 || deleteTime < 0)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument");
                }

                hideTimeout = hideTime;
                deleteTimeout = deleteTime;
            }

            /// <summary>
            /// Method to get times to hide or delete notification.
            /// </summary>
            /// <param name="hideTime">The value in second when the notification can be hidden from the notification viewer after notification is posted</param>
            /// <param name="deleteTime">The value in second when the notification can be deleted from the notification list in setting application after notification is posted</param>
            public void GetRemoveTime(out int hideTime, out int deleteTime)
            {
                hideTime = hideTimeout;
                deleteTime = deleteTimeout;
            }

            /// <summary>
            /// Method to add a button to the active notification style.
            /// Buttons are displayed on the notification.
            /// </summary>
            /// <remarks>
            /// If you add button that has same index, the button is replaced to latest adding button.
            /// If you don't set an index on ButtonAction, the index is set sequentially from zero.
            /// </remarks>
            /// <param name="button">An ButtonAction for appear to the notification</param>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            /// <example>
            /// <code>
            ///
            /// ButtonAction button = new ButtonAction
            /// {
            ///     Index = 0,
            ///     Text = "Yes"
            ///     Action = new AppControl{ ApplicationId = "org.tizen.app" };
            /// };
            ///
            /// ActiveStyle active = new ActiveStyle
            /// {
            ///     IsAutoRemove = true,
            ///     BackgroundImage = "image path",
            /// };
            ///
            /// active.AddButtonAction(button);
            ///
            /// </code>
            /// </example>
            public void AddButtonAction(ButtonAction button)
            {
                if (button == null)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid ButtonAction object");
                }

                if (button.Index == ButtonIndex.None)
                {
                    button.Index = (ButtonIndex)buttonDictionary.Count;
                    buttonDictionary.Add(button.Index, button);
                }
                else if (button.Index >= ButtonIndex.First)
                {
                    if (buttonDictionary.ContainsKey(button.Index))
                    {
                        buttonDictionary.Remove(button.Index);
                    }

                    buttonDictionary.Add(button.Index, button);
                }
            }

            /// <summary>
            /// Remove the ButtonAction you already add.
            /// </summary>
            /// <param name="index">The index to remove a button</param>
            /// <returns>true if the element is successfully found and removed; otherwise, false</returns>
            public bool RemoveButtonAction(ButtonIndex index)
            {
                bool ret = buttonDictionary.Remove(index);

                if (ret == false)
                {
                    Log.Debug(Notification.LogTag, "Invalid key, there is no button matched input index");
                }
                else
                {
                    Log.Debug(Notification.LogTag, "The button was removed.");
                }

                return ret;
            }

            /// <summary>
            /// Gets the ButtonAction of the active notification.
            /// </summary>
            /// <param name="index">The index to get a button you already add</param>
            /// <returns>The ButtonAction object which is you already add</returns>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            public ButtonAction GetButtonAction(ButtonIndex index)
            {
                ButtonAction button = null;

                if (buttonDictionary.ContainsKey(index) == true)
                {
                    buttonDictionary.TryGetValue(index, out button);
                }
                else
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The value is not existed.");
                }

                return button;
            }

            internal ICollection<ButtonAction> GetButtonAction()
            {
                return buttonDictionary.Values;
            }

            internal override void Make(Notification notification)
            {
                ActiveBinder.BindObject(notification);
            }
        }
    }
}