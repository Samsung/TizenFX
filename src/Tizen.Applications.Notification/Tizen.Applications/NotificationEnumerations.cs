/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Enumeration for Notification Type
    /// </summary>
    public enum NotificationType : short
    {
        /// <summary>
        /// Value representing thumbnail and event notifications
        /// </summary>
        Event = 0,
        /// <summary>
        /// Value representing progress notifications
        /// </summary>
        Progress
    }

    /// <summary>
    /// Enumeration for Notification applications
    /// </summary>
    [Flags]
    public enum NotificationArea
    {
        /// <summary>
        /// Value for applying no applist.
        /// </summary>
        None = 0,
        /// <summary>
        /// Value for notification tray app
        /// </summary>
        NotificationTray = 1,
        /// <summary>
        /// Value for ticker app
        /// </summary>
        Ticker = 1 << 1,
        /// <summary>
        /// Value for indicator app
        /// </summary>
        Indicator = 1 << 3,
        /// <summary>
        /// Value for active notification
        /// </summary>
        Active = 1 << 4
    }

    /// <summary>
    /// Enumeration for adding a button to an event notification
    /// </summary>
    public enum ButtonIndex : short
    {
        /// <summary>
        /// Value to add a button for positive response
        /// </summary>
        Positive = 0,
        /// <summary>
        /// Value to add a button for negative response
        /// </summary>
        Negative
    }

    internal enum SoundOption
    {
        Off = -1,
        Default,
        Custom
    }

    internal enum VibrationOption
    {
        Off = -1,
        Default,
        Custom
    }

    internal enum LedOption
    {
        Off = -1,
        On = 1
    }

    internal enum NotiLayout
    {
        SingleEvent = 1,
        Thumbnail = 3,
        Progress = 5
    }

    internal enum NotiText
    {
        Title = 0,
        Content,
        EventCount = 3,
        FirstMainText,
        FirstSubText,
        SecondMainText,
        SecondSubText,
        PositiveButton = 13,
        NegativeButton
    }

    internal enum NotiImage
    {
        Icon = 0,
        Indicator,
        Thumbnail = 3,
        SubIcon = 5,
        Background,
        PositiveButton = 12,
        NegativeButton
    }

    internal enum LaunchOption
    {
        AppControl = 1
    }
}
