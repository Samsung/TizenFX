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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class contains common properties and methods of notifications.
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public sealed partial class Notification
    {
        /// <summary>
        ///  Class for generating active style notification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public sealed class ActiveStyle : StyleBase
        {
            private IDictionary<ButtonIndex, ButtonAction> buttonDictionary;
            private int hideTimeout = 0;
            private int deleteTimeout = 0;

            /// <summary>
            /// Initializes a new instance of the <see cref="ActiveStyle"/> class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public ActiveStyle()
            {
                buttonDictionary = new Dictionary<ButtonIndex, ButtonAction>();
            }

            /// <summary>
            /// Gets or sets an absolute path for an image file to display on the background of active notification.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public string BackgroundImage { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the active notification is removed automatically. Default value is true.
            /// </summary>
            /// <remarks>
            /// IsAutoRemove option lets the active notification to be removed several seconds after it shows.
            /// When 'IsAutoRemove' is set as false, the active notification will not be removed as long as the user removes
            /// it or the application, which posted the active notification.
            /// </remarks>
            /// <since_tizen> 3 </since_tizen>
            public bool IsAutoRemove { get; set; } = true;

            /// <summary>
            /// Gets or sets the default button to display highlight on the active notification.
            /// </summary>
            /// <remarks>
            /// The default button for display highlight is only reflected on the Tizen TV.
            /// If you use this property on other profile, this value has no effect.
            /// </remarks>
            /// <since_tizen> 3 </since_tizen>
            public ButtonIndex DefaultButton { get; set; } = ButtonIndex.None;

            /// <summary>
            /// Gets or sets a ReplyAction to this active notification style.
            /// </summary>
            /// <remarks>
            /// When you add a ReplyAction to the ActiveStyle, the notification UI will show a ReplyAction with button.
            /// If you set null parameter, ReplyAction is not displayed.
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
            /// <since_tizen> 3 </since_tizen>
            public ReplyAction ReplyAction { get; set; }

            /// <summary>
            /// Gets or sets Action which is invoked when notification is hidden by user.
            /// </summary>
            /// <remarks>
            /// If you set it to null, the already set AppControl will be removed and nothing will happen when notification is hidden by user.
            /// The property is only reflected on Tizen TV.
            /// If you use this API on other profile, this action have no effect
            /// </remarks>
            /// <seealso cref="Tizen.Applications.AppControl"></seealso>
            /// <since_tizen> 4 </since_tizen>
            public AppControl HiddenByUserAction { get; set; }

            /// <summary>
            /// Gets or sets Action which is invoked when there is no any response by user until hide timeout.
            /// </summary>
            /// <remarks>
            /// This action occurs when there is no response to the notification until the delete timeout set by SetRemoveTime().
            /// If you set it to null, the already set AppControl will be removed and nothing will happen when notification is hidden by timeout.
            /// The property is only reflected on Tizen TV.
            /// If you use this API on other profile, this action settings have no effect
            /// </remarks>
            /// <seealso cref="Tizen.Applications.AppControl"></seealso>
            /// <since_tizen> 4 </since_tizen>
            public AppControl HiddenByTimeoutAction { get; set; }

            /// <summary>
            /// Gets or sets Action which is invoked when the notification is hidden by external factor.
            /// </summary>
            /// <remarks>
            /// If you set it to null, the already set AppControl will be removed and nothing will happen when notification is hidden by external factor.
            /// The property is only reflected on Tizen TV.
            /// If you use this API on other profile, this action settings have no effect
            /// </remarks>
            /// <seealso cref="Tizen.Applications.AppControl"></seealso>
            /// <since_tizen> 4 </since_tizen>
            public AppControl HiddenByExternalAction { get; set; }

            /// <summary>
            /// Gets the key of ActiveStyle.
            /// </summary>
            internal override string Key
            {
                get
                {
                    return "Active";
                }
            }

            /// <summary>
            /// Method to set time to hide or delete notification.
            /// </summary>
            /// <remarks>
            /// The time settings for hiding and deleting are only reflected on the Tizen TV.
            /// If you use this API on other profile, this time settings have no effect.
            /// </remarks>
            /// <param name="hideTime">The value in seconds when the notification can be hidden from the notification viewer after the notification is posted.</param>
            /// <param name="deleteTime">The value in seconds when the notification can be deleted from the notification list in setting application after notification is posted.</param>
            /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
            /// <since_tizen> 3 </since_tizen>
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
            /// Method to get time set to hide or delete notification.
            /// </summary>
            /// <param name="hideTime">The value in seconds when the notification can be hidden from the notification viewer after notification is posted.</param>
            /// <param name="deleteTime">The value in seconds when the notification can be deleted from the notification list in setting application after notification is posted.</param>
            /// <since_tizen> 3 </since_tizen>
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
            /// <param name="button">A ButtonAction for appear to the notification.</param>
            /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
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
            /// <since_tizen> 3 </since_tizen>
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
            /// Removes the ButtonAction you already added.
            /// </summary>
            /// <param name="index">The index to remove a button.</param>
            /// <returns>true if the element is successfully found and removed; otherwise, false.</returns>
            /// <since_tizen> 3 </since_tizen>
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
            /// <param name="index">The index to get a button you already added.</param>
            /// <returns>The ButtonAction object, which you already added.</returns>
            /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
            /// <since_tizen> 3 </since_tizen>
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
