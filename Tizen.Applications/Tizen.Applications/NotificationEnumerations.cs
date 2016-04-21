// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
        /// Value for applying no applist. Default
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
    /// Enumeration for Button indices for Base Notifications
    /// </summary>
    public enum ButtonIndex : short
    {
        /// <summary>
        /// Value for first index
        /// </summary>
        Positive = 0,
        /// <summary>
        /// Value for second index
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
