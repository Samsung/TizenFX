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
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Enumeration for Progress category
    /// </summary>
    public enum ProgressCategory
    {
        /// <summary>
        /// Value for percent type
        /// </summary>
        Percent,

        /// <summary>
        /// Value for time type
        /// </summary>
        Time,

        /// <summary>
        /// Value for pending type which is not updated progress current value
        /// </summary>
        PendingBar
    }

    /// <summary>
    /// Enumeration for Accessory option
    /// </summary>
    public enum AccessoryOption
    {
        /// <summary>
        /// Value for off accessory option
        /// </summary>
        Off = -1,

        /// <summary>
        /// Value for on accessory option
        /// </summary>
        On,

        /// <summary>
        /// Value for custom accessory option
        /// </summary>
        Custom
    }

    /// <summary>
    /// Enumeration for Button Index
    /// </summary>
    public enum ButtonIndex
    {
        /// <summary>
        /// Value for default button index
        /// </summary>
        None = -1,

        /// <summary>
        /// Value for first button index
        /// </summary>
        First,

        /// <summary>
        /// Value for second button index
        /// </summary>
        Second,

        /// <summary>
        /// Value for third button index
        /// </summary>
        Third
    }

    /// <summary>
    /// Enumeration for notification particular property
    /// </summary>
    [Flags]
    public enum NotificationProperty
    {
        /// <summary>
        /// Value for adjust nothing
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Value for display only SIM card inserted
        /// </summary>
        DisplayOnlySimMode = 0x01,

        /// <summary>
        /// Value for disable application launch when it selected
        /// </summary>
        DisableAppLaunch = 0x02,

        /// <summary>
        /// Value for disable auto delete when it selected
        /// </summary>
        DisableAutoDelete = 0x04,

        /// <summary>
        /// Value for deleted when device is rebooted even though notification is not set OngoingType
        /// </summary>
        VolatileDisplay = 0x100,
    }

    /// <summary>
    /// Enumeration for event type on notification.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum UserEventType
    {
        /// <summary>
        /// Event type : Click on button 1
        /// </summary>
        ClickOnButton1 = 0,

        /// <summary>
        /// Event type : Click on button 2
        /// </summary>
        ClickOnButton2,

        /// <summary>
        /// Event type : Click on button 3
        /// </summary>
        ClickOnButton3,

        /// <summary>
        /// Event type : Click on text_input button
        /// </summary>
        ClickOnReplyButton = 8,

        /// <summary>
        /// Event type : Hidden by user
        /// </summary>
        HiddenByUser = 100,

        /// <summary>
        /// Event type : Deleted by timer
        /// </summary>
        HiddenByTimeout = 101,

        /// <summary>
        /// Event type : Clicked by user
        /// </summary>
        ClickOnNotification = 200,

        /// <summary>
        /// Event type : Deleted by user
        /// </summary>
        DeleteNotification = 201,
    }

    /// <summary>
    /// Enumeration for notification type.
    /// </summary>
    internal enum NotificationType
    {
        /// <summary>
        /// Notification type
        /// </summary>
        Notification = 0,

        /// <summary>
        /// Ongoing type
        /// </summary>
        Ongoing,
    }

    /// <summary>
    /// Enumeration for notification text type.
    /// </summary>
    internal enum NotificationText
    {
        /// <summary>
        /// Title
        /// </summary>
        Title = 0,

        /// <summary>
        /// Content
        /// </summary>
        Content,

        /// <summary>
        /// Text to display event count
        /// </summary>
        EventCount = 3,

        /// <summary>
        /// Box contents 1
        /// </summary>
        FirstMainText,

        /// <summary>
        /// Box contents 1-1
        /// </summary>
        FirstSubText,

        /// <summary>
        /// Box contents 2
        /// </summary>
        SecondMainText,

        /// <summary>
        /// Box contents 2-1
        /// </summary>
        SecondSubText,

        /// <summary>
        /// Text on button 1
        /// </summary>
        FirstButton = 13,

        /// <summary>
        /// Text on button 2
        /// </summary>
        SecondButton,

        /// <summary>
        /// Text on button 3
        /// </summary>
        ThirdButton,

        /// <summary>
        /// Guide text on the message reply box
        /// </summary>
        PlaceHolder = 19,

        /// <summary>
        /// Text on button the on message reply box
        /// </summary>
        InputButton = 20,
    }

    /// <summary>
    /// Enumeration for image type.
    /// </summary>
    internal enum NotificationImage
    {
        /// <summary>
        /// Icon
        /// </summary>
        Icon = 0,

        /// <summary>
        /// Indicator icon
        /// </summary>
        Indicator,

        /// <summary>
        ///  Lock screen icon
        /// </summary>
        Lockscreen,

        /// <summary>
        /// Thumbnail
        /// </summary>
        Thumbnail,

        /// <summary>
        /// Lock screen thumbnail
        /// </summary>
        ThumbnailLockscreen,

        /// <summary>
        /// Icon
        /// </summary>
        SubIcon,

        /// <summary>
        /// image displayed on background
        /// </summary>
        Background,

        /// <summary>
        /// Image for button 1
        /// </summary>
        Button_1 = 12,

        /// <summary>
        /// Image for button 2
        /// </summary>
        Button_2,

        /// <summary>
        /// Image for button 3
        /// </summary>
        Button_3,

        /// <summary>
        /// Image for message reply
        /// </summary>
        TextInputButton = 18,
    }

    /// <summary>
    /// Enumeration for notification layout type.
    /// </summary>
    internal enum NotificationLayout
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Layout for notification. Used to inform single event
        /// </summary>
        SingleEvent = 1,

        /// <summary>
        /// Layout for notification. Used to display images
        /// </summary>
        Thumbnail = 3,

        /// <summary>
        /// Layout for ongoing notification. Used to display text message
        /// </summary>
        OngoingEvent = 4,

        /// <summary>
        /// Layout for ongoing notification. Used to display progress
        /// </summary>
        OngoingProgress = 5,
    }

    /// <summary>
    /// Enumeration for notification launch option type.
    /// </summary>
    internal enum LaunchOption
    {
        /// <summary>
        /// Launching with app control
        /// </summary>
        AppControl = 1
    }

    /// <summary>
    /// Enumeration for notification operation data code.
    /// </summary>
    internal enum NotificationOperationDataType
    {
        /// <summary>
        /// Default
        /// </summary>
        Min = 0,

        /// <summary>
        /// Operation type
        /// </summary>
        Type,

        /// <summary>
        /// Private ID
        /// </summary>
        UniqueNumber,

        /// <summary>
        /// Notification handler
        /// </summary>
        Notification,

        /// <summary>
        /// Reserved
        /// </summary>
        ExtraInformation1,

        /// <summary>
        /// Reserved
        /// </summary>
        ExtraInformation2,
    }

    /// <summary>
    /// Enumeration for notification operation code.
    /// </summary>
    internal enum NotificationOperationType
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Notification inserted
        /// </summary>
        Insert,

        /// <summary>
        /// Notification updated
        /// </summary>
        Update,

        /// <summary>
        /// Notification deleted
        /// </summary>
        Delete,
    }

    /// <summary>
    /// Enumeration for event type on notification.
    /// </summary>
    internal enum ClickEventType
    {
        /// <summary>
        /// Event type : Click on button 1
        /// </summary>
        FirstButton = 0,

        /// <summary>
        /// Event type : Click on button 2
        /// </summary>
        SecondButton = 1,

        /// <summary>
        /// Event type : Click on button 3
        /// </summary>
        ThirdButton = 2,

        /// <summary>
        /// Event type : Click on icon
        /// </summary>
        Icon = 6,

        /// <summary>
        /// Event type : Click on thumbnail
        /// </summary>
        Thumbnail = 7,

        /// <summary>
        /// Event type : Click on text_input button
        /// </summary>
        InputButton = 8,
    }

    /// <summary>
    /// Enumeration for display application list.
    /// </summary>
    [Flags]
    internal enum NotificatioDisplayApplist
    {
        /// <summary>
        /// Notification Tray(Quickpanel)
        /// </summary>
        Tray = 0x00000001,

        /// <summary>
        /// Ticker notification
        /// </summary>
        Ticker = 0x00000002,

        /// <summary>
        /// Lock screen
        /// </summary>
        Lock = 0x00000004,

        /// <summary>
        /// Indicator
        /// </summary>
        Indicator = 0x00000008,

        /// <summary>
        /// Active notification
        /// </summary>
        Active = 0x00000010,

        /// <summary>
        /// All display application except active notification
        /// </summary>
        All = 0x0000000f,
    }
}
