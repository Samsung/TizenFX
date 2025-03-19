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

    /// <summary>
    /// Enumeration for the progress category.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProgressCategory
    {
        /// <summary>
        /// Value for percent type.
        /// </summary>
        Percent,

        /// <summary>
        /// Value for time type.
        /// </summary>
        Time,

        /// <summary>
        /// Value for pending type, which is not the updated progress current value.
        /// </summary>
        PendingBar
    }

    /// <summary>
    /// Enumeration for the accessory option.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AccessoryOption
    {
        /// <summary>
        /// Value for off accessory option.
        /// </summary>
        Off = -1,

        /// <summary>
        /// Value for on accessory option.
        /// </summary>
        On,

        /// <summary>
        /// Value for the custom accessory option.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Enumeration for the button index.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ButtonIndex
    {
        /// <summary>
        /// Value for the default button index.
        /// </summary>
        None = -1,

        /// <summary>
        /// Value for the first button index.
        /// </summary>
        First,

        /// <summary>
        /// Value for the second button index.
        /// </summary>
        Second,

        /// <summary>
        /// Value for the third button index.
        /// </summary>
        Third
    }

    /// <summary>
    /// Enumeration for the notification particular property.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum NotificationProperty
    {
        /// <summary>
        /// Value for adjust nothing.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Value for display only SIM card inserted.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        DisplayOnlySimMode = 0x01,

        /// <summary>
        /// Value for disable application launch when it is selected.
        /// </summary>
        DisableAppLaunch = 0x02,

        /// <summary>
        /// Value for disable auto delete when it is selected.
        /// </summary>
        DisableAutoDelete = 0x04,

        /// <summary>
        /// Value for deleted when device is rebooted even though notification is not set ongoing.
        /// </summary>
        VolatileDisplay = 0x100
    }

    /// <summary>
    /// Enumeration for the block state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NotificationBlockState
    {
        /// <summary>
        /// Value to check if the app is allowed to post notification.
        /// </summary>
        Allowed = 0,

        /// <summary>
        /// Value to check if the app is not allowed to post any notification.
        /// </summary>
        Blocked,

        /// <summary>
        /// Value to check if the do not disturb mode is set by the user.
        /// </summary>
        DoNotDisturb
    }

    internal enum NotificationType
    {
        None = -1,
        Basic = 0,
        Ongoing,
    }

    internal enum NotificationEventType
    {
        FirstButton = 0,
        SecondButton,
        ThirdButton,
        ClickOnIcon = 6,
        ClickOnThumbnail = 7,
        ClickOnTextInputButton = 8,
        HiddenByUser = 100,
        HiddenByTimeout = 101,
        HiddenByExternal = 102,
    }

    internal enum NotificationLayout
    {
        None = 0,
        SingleEvent = 1,
        Thumbnail = 3,
        Ongoing = 4,
        Progress = 5,
        Extension = 6
    }

    internal enum NotificationText
    {
        Title = 0,
        Content,
        EventCount = 3,
        FirstMainText,
        FirstSubText,
        SecondMainText,
        SecondSubText,
        GroupTitle = 10,
        GroupContent = 11,
        FirstButton = 13,
        SeceondButton = 14,
        ThirdButton = 15,
        PlaceHolder = 19,
        InputButton = 20,
    }

    internal enum NotificationImage
    {
        Icon = 0,
        IconForIndicator,
        IconForLock,
        Thumbnail,
        ThumbnailForLock,
        SubIcon,
        Background,
        FirstButton = 12,
        SecondButton,
        ThirdButton,
        TextInputButton = 18,
        Extension = 19,
    }

    internal enum LaunchOption
    {
        AppControl = 1
    }

    [Flags]
    internal enum NotificationDisplayApplist
    {
        Tray = 0x00000001,
        Ticker = 0x00000002,
        Lock = 0x00000004,
        Indicator = 0x00000008,
        Active = 0x00000010,
        All = 0x0000000f,
    }
}
