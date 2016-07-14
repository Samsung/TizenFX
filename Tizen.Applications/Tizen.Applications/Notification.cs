// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.UI;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Structure containing led on and off periods for making led blink
    /// </summary>
    public struct LedBlinkPeriod
    {
        /// <summary>
        /// Constructor to initialize values for led on and off times
        /// </summary>
        /// <param name="on">On time of led in milliseconds</param>
        /// <param name="off">Off time of led in milliseconds</param>
        public LedBlinkPeriod(int on, int off)
        {
            OnTime = on;
            OffTime = off;
        }

        /// <summary>
        /// Time in milliseconds for which led turns on
        /// </summary>
        public int OnTime
        {
            get;
            set;
        }

        /// <summary>
        /// Time in milliseconds for which led turns off
        /// </summary>
        public int OffTime
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Class containing common properties and methods of Notifications
    /// </summary>
    public abstract class Notification
    {
        internal const string _logTag = "Tizen.Applications.Notification";

        internal Interop.Notification.SafeNotificationHandle _handle;

        private const int DisableAppLaunchMask = 1 << 1;

        private const int DisableAutoDeleteMask = 1 << 2;

        private const int VolatileDisplayMask = 1 << 8;

        private string _soundPath = string.Empty;

        private string _vibrationPath = null;

        private Color _ledColor = new Color(0, 0, 0, 0);

        /// <summary>
        /// Insert time of Notification. Default is 1 Jan 1970 9:00:00 until notification is posted.
        /// </summary>
        /// <value>
        /// InsertTime contains value at which the notification is posted.
        /// InsertTime requires NotificationManager.Post to be called else InsertTime defaults to 1 Jan 1970 9:00:00.
        /// </value>
        /// <example>
        /// <code>
        /// Notification noti = new EventNotification();
        /// NotificationManager.Post(noti);
        /// Log.Debug(LogTag, "Insert Time: " + noti.InsertTime);
        /// </code>
        /// </example>
        public DateTime InsertTime
        {
            get
            {
                long time;
                int ret = Interop.Notification.GetInsertTime(_handle, out time);
                if (ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get insert time");
                    return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(0).ToLocalTime();
                }

                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(time).ToLocalTime();
            }
        }

        /// <summary>
        /// Title of Notification. Defaults to empty string.
        /// </summary>
        /// <example>
        /// <code>
        /// string title = "New Message";
        /// Notification noti = new EventNotification();
        /// noti.Title = title;
        /// Log.Debug(LogTag, "Title: " + noti.Title);
        /// </code>
        /// </example>
        public string Title
        {
            get
            {
                IntPtr titlePtr;
                int ret = Interop.Notification.GetText(_handle, NotiText.Title, out titlePtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get title");
                    return string.Empty;
                }

                if (titlePtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(titlePtr);
            }
            set
            {
                int ret = Interop.Notification.SetText(_handle, NotiText.Title, value, null, -1);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set title");
                }
            }
        }

        /// <summary>
        /// Content of Notification. Defaults to empty string.
        /// </summary>
        /// <example>
        /// <code>
        /// string title = "New Message";
        /// string content = "How are you?"
        /// Notification noti = new EventNotification();
        /// noti.Title = title;
        /// noti.Content = content;
        /// Log.Debug(LogTag, "Content: " + noti.Content);
        /// </code>
        /// </example>
        public string Content
        {
            get
            {
                IntPtr contentPtr;
                int ret = Interop.Notification.GetText(_handle, NotiText.Content, out contentPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get content");
                    return string.Empty;
                }

                if (contentPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(contentPtr);
            }
            set
            {
                int ret = Interop.Notification.SetText(_handle, NotiText.Content, value, null, -1);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set content");
                }
            }
        }

        /// <summary>
        /// Gets and sets Icon image Path. Defaults to empty string.
        /// </summary>
        /// <value>
        /// Image whose path is set can be seen on the notification when the Notification tray is opened.
        /// </value>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"notification.png";
        /// Notification noti = new EventNotification();
        /// noti.IconPath = imagePath;
        /// Log.Debug(LogTag, "Image Path: " + noti.IconPath);
        /// </code>
        /// </example>
        public string IconPath
        {
            get
            {
                IntPtr pathPtr;
                int ret = Interop.Notification.GetImage(_handle, NotiImage.Icon, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get icon image path");
                    return string.Empty;
                }

                if (pathPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(pathPtr);
            }
            set
            {
                int ret = Interop.Notification.SetImage(_handle, NotiImage.Icon, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set icon image path");
                }
            }
        }

        /// <summary>
        /// Gets and sets Indicator icon image Path. Defaults to empty string.
        /// </summary>
        /// <value>
        /// Image whose path is set can be seen on the indicator when the notification is posted using NotificationManager.Post method.
        /// </value>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"notification.png";
        /// Notification noti = new EventNotification();
        /// noti.IndicatorIconPath = imagePath;
        /// Log.Debug(LogTag, "Image Path: " + noti.IndicatorIconPath);
        /// </code>
        /// </example>
        public string IndicatorIconPath
        {
            get
            {
                IntPtr pathPtr;
                int ret = Interop.Notification.GetImage(_handle, NotiImage.Indicator, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get indicator icon image path");
                    return string.Empty;
                }

                if (pathPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(pathPtr);
            }
            set
            {
                int ret = Interop.Notification.SetImage(_handle, NotiImage.Indicator, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set indicator icon image path");
                }
            }
        }

        /// <summary>
        /// Gets and sets Background image Path. Defaults to string.Empty.
        /// </summary>
        /// <value>
        /// Image whose path is set can be seen on the notification when the Notification tray is opened.
        /// </value>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"background.png";
        /// Notification noti = new EventNotification();
        /// noti.BackgroundImagePath = imagePath;
        /// Log.Debug(LogTag, "Image Path: " + noti.BackgroundImagePath);
        /// </code>
        /// </example>
        public string BackgroundImagePath
        {
            get
            {
                IntPtr pathPtr;
                int ret = Interop.Notification.GetImage(_handle, NotiImage.Background, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get background path");
                    return string.Empty;
                }

                if (pathPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(pathPtr);
            }
            set
            {
                int ret = Interop.Notification.SetImage(_handle, NotiImage.Background, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set background path");
                }
            }
        }

        /// <summary>
        /// Gets and sets SubIcon image Path. Defaults to empty string.
        /// </summary>
        /// <value>
        /// Image whose path is set can be seen on the notification when the Notification tray is opened.
        /// </value>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"background.png";
        /// Notification noti = new EventNotification();
        /// noti.SubIconPath = imagePath;
        /// Log.Debug(LogTag, "Image Path: " + noti.SubIconPath);
        /// </code>
        /// </example>
        public string SubIconPath
        {
            get
            {
                IntPtr pathPtr;
                int ret = Interop.Notification.GetImage(_handle, NotiImage.SubIcon, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get sub icon path");
                    return string.Empty;
                }

                if (pathPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(pathPtr);
            }
            set
            {
                int ret = Interop.Notification.SetImage(_handle, NotiImage.SubIcon, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set sub icon path");
                }
            }
        }

        /// <summary>
        /// Gets and sets Tag. Defaults to empty string.
        /// </summary>
        /// <value>
        /// User can set Tag to a particular string to a notification and use in conjunction with NotificationManager.Load method to retrieve its notification object.
        /// </value>
        /// <example>
        /// <code>
        /// string tag = "firstNotification";
        /// Notification noti = EventNotification();
        /// noti.Tag = tag;
        /// NotificationManager.Post(noti);
        /// /// ...
        /// Notification notiCopy = NotificationManager.Load/<Notification/>(tag);
        /// </code>
        /// </example>
        public string Tag
        {
            get
            {
                IntPtr tagPtr;
                int ret = Interop.Notification.GetTag(_handle, out tagPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get tag");
                    return string.Empty;
                }

                if (tagPtr == IntPtr.Zero)
                    return string.Empty;

                return Marshal.PtrToStringAuto(tagPtr);
            }
            set
            {
                int ret = Interop.Notification.SetTag(_handle, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set tag");
                }
            }
        }

        /// <summary>
        /// Gets and sets Areas to display the notification. Defaults to NotificaitonTray | Ticker | Indicator.
        /// </summary>
        /// <example>
        /// <code>
        /// NotificationArea area = NotificationArea.NotificationTray | NotificationArea.Indicator;
        /// Notification noti = EventNotification();
        /// noti.NotificationArea = area;
        /// Log.Debug(LogTag, "Notification Areas: " + noti.NotificationArea);
        /// </code>
        /// </example>
        public NotificationArea NotificationArea
        {
            get
            {
                int appList;
                int ret = Interop.Notification.GetApplist(_handle, out appList);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable get applist");
                    return NotificationArea.None;
                }

                return (NotificationArea)appList;
            }
            set
            {
                int ret = Interop.Notification.SetApplist(_handle, (int)value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set applist");
                }
            }
        }

        /// <summary>
        /// Gets the Notification Type.
        /// </summary>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// Log.Debug(LogTag, "Notification Type: " + noti.NotificationType);
        /// </code>
        /// </example>
        public NotificationType NotificationType
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets and sets the Led on and off times in milliseconds. Defaults to 0 for both.
        /// </summary>
        /// <value>
        /// LedBlinkPeriod is used with LedEnabled to make the led blink
        /// </value>
        /// <example>
        /// <code>
        /// LedBlinkPeriod period = new LedBlinkPeriod(1000, 500);
        /// Notification noti = new ProgressNotification();
        /// noti.LedBlinkPeriod = period;
        /// noti.LedEnabled = true;
        /// </code>
        /// </example>
        public LedBlinkPeriod LedBlinkPeriod
        {
            get
            {
                int on;
                int off;
                int ret = Interop.Notification.GetLedTimePeriod(_handle, out on, out off);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get led time period");
                    return new LedBlinkPeriod(0,0);
                }

                return new LedBlinkPeriod(on, off);
            }
            set
            {
                int ret = Interop.Notification.SetLedTimePeriod(_handle, value.OnTime, value.OffTime);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set led time period");
                }
            }
        }

        /// <summary>
        /// Gets and sets value to enable/disable sound for a notification. False by default.
        /// </summary>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// noti.SoundEnabled = true;
        /// Log.Debug(LogTag, "Sound Enabled: " + noti.SoundEnabled);
        /// </code>
        /// </example>
        public bool SoundEnabled
        {
            get
            {
                SoundOption enabled;
                IntPtr pathPtr;

                int ret = Interop.Notification.GetSound(_handle, out enabled, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get sound enabled");
                    return false;
                }

                if(enabled >= SoundOption.Default)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                int ret;
                if(value)
                {
                    ret = Interop.Notification.SetSound(_handle, _soundPath == string.Empty || _soundPath == null ? SoundOption.Default : SoundOption.Custom, _soundPath);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set sound enabled ");
                    }
                }
                else
                {
                    ret = Interop.Notification.SetSound(_handle, SoundOption.Off, null);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable disable sound");
                    }
                }
            }
        }

        /// <summary>
        /// Get and set path of custom sound file to be played for notification.Defaults to string.Empty.
        /// </summary>
        /// <value>
        /// If SoundPath is not set or set to String.Empty or null default sound is played.
        /// </value>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string soundPath = dir.Resource+"sound.wav";
        /// Notification noti = new ProgressNotification();
        /// noti.SoundEnabled = true;
        /// noti.SoundPath = soundPath;
        /// Log.Debug(LogTag, "Sound Path: " + noti.SoundPath);
        /// </code>
        /// </example>
        public string SoundPath
        {
            get
            {
                SoundOption enabled;
                IntPtr pathPtr;
                int ret = Interop.Notification.GetSound(_handle, out enabled, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get sound path");
                    return string.Empty;
                }

                if(pathPtr != IntPtr.Zero)
                    _soundPath = Marshal.PtrToStringAuto(pathPtr);

                return _soundPath;
            }
            set
            {
                int ret;
                IntPtr pathPtr;
                SoundOption enabled;

                ret = Interop.Notification.GetSound(_handle, out enabled, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to get sound enabled");
                }

                if(enabled >= SoundOption.Default)
                {
                    ret = Interop.Notification.SetSound(_handle, value == string.Empty || _soundPath == null ? SoundOption.Default : SoundOption.Custom, value);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set sound path");
                    }
                }

                _soundPath = value;
            }
        }

        /// <summary>
        /// Gets and sets value to enable/disable vibration for a notification. Defaults to false;
        /// </summary>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// noti.VibrationEnabled = true;
        /// Log.Debug(LogTag, "Vibration Enabled: " + noti.VibrationEnabled);
        /// </code>
        /// </example>
        public bool VibrationEnabled
        {
            get
            {
                VibrationOption enabled;
                IntPtr pathPtr;
                int ret = Interop.Notification.GetVibration(_handle, out enabled, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get vibration enabled");
                    return false;
                }

                if(enabled >= VibrationOption.Default)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                int ret;
                if(value)
                {
                    ret = Interop.Notification.SetVibration(_handle, _vibrationPath == null ? VibrationOption.Default : VibrationOption.Custom, _vibrationPath);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set vibration enabled ");
                    }
                }
                else
                {
                    ret = Interop.Notification.SetVibration(_handle, VibrationOption.Off, null);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable disable vibration");
                    }
                }
            }
        }

        /// <summary>
        /// Get and sets value to enable/disable led. Defaults to false.
        /// </summary>
        /// <value>
        /// LedEnabled needs to be set to true as well as LedBlinkPeriod and LedColor must be set to appropriate values to make the led blink.
        /// </value>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// noti.LedEnabled = true;
        /// noti.LedColor = Color.Blue;
        /// noti.LedBlinkPeriod = new LedBlinkPeriod(100, 100);
        /// Log.Debug(LogTag, "Led Enabled: " + noti.LedEnabled);
        /// </code>
        /// </example>
        public bool LedEnabled
        {
            get
            {
                LedOption enabled;
                int c;
                int ret = Interop.Notification.GetLed(_handle, out enabled, out c);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get led enabled");
                    return false;
                }

                if(enabled >= LedOption.On)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                int ret;
                if(value)
                {
                    ret = Interop.Notification.SetLed(_handle, LedOption.On, _ledColor.GetArgb());
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set led enabled");
                    }
                }
                else
                {
                    ret = Interop.Notification.SetLed(_handle, LedOption.Off, 0);
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set led enabled");
                    }
                }
            }
        }

        /// <summary>
        /// Gets and sets custom led color for led. Default to Color(0, 0, 0, 0).
        /// </summary>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// noti.LedEnabled = true;
        /// noti.LedColor = Color.Red;
        /// Log.Debug(LogTag, "Led Color: " + noti.LedColor.ToString());
        /// </code>
        /// </example>
        public Color LedColor
        {
            get
            {
                LedOption enabled;
                int c;
                int ret = Interop.Notification.GetLed(_handle, out enabled, out c);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get led color");
                    return _ledColor;
                }

                if(c != 0)
                    _ledColor = new Color(c >> 16 & 255, c >> 8 & 255, c >> 0 & 255, c >> 24 & 255);

                return _ledColor;
            }
            set
            {
                LedOption enabled;
                int c;
                int ret = Interop.Notification.GetLed(_handle, out enabled, out c);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to get led enabled");
                }

                if(enabled >= LedOption.On)
                {
                    ret = Interop.Notification.SetLed(_handle, LedOption.On, value.GetArgb());
                    if(ret != (int)NotificationError.None)
                    {
                        throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set led color");
                    }
                }

                _ledColor = value;
            }
        }

        /// <summary>
        /// Gets and sets value to enable/disable Volatile Display property. Defaults to false.
        /// </summary>
        /// <value>
        /// Volatile display property makes a notification to be cleared on reboot if it is set to true.
        /// </value>
        /// <example>
        /// <code>
        /// Notification noti = new ProgressNotification();
        /// noti.VolatileDisplayEnabled = true;
        /// Log.Debug(LogTag, "Volatile Display: " + noti.VolatileDisplayEnabled);
        /// </code>
        /// </example>
        public bool VolatileDisplayEnabled
        {
            get
            {
                int result;
                int ret = Interop.Notification.GetProperties(_handle, out result);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get disable app launch");
                    return false;
                }

                if((result & VolatileDisplayMask) != 0)
                    return true;
                else
                    return false;
            }
            set
            {
                int result = 0;

                int ret = Interop.Notification.GetProperties(_handle, out result);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to get property values");
                }

                if(value)
                    result = result | VolatileDisplayMask;
                else
                    result = result & ~VolatileDisplayMask;

                ret = Interop.Notification.SetProperties(_handle, result);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set properties");
                }
            }
        }

        /// <summary>
        /// Gets and sets Thumbnail path for notification. Defaults to string.Empty.
        /// </summary>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"thumb.png";
        /// Notification noti = new EventNotification();
        /// noti.ThumbnailPath = imagePath;
        /// Log.Debug(LogTag, "Image Path: " + noti.ThumbnailPath);
        /// </code>
        /// </example>
        public string ThumbnailPath
        {
            get
            {
                IntPtr pathPtr;
                string path;
                int ret = Interop.Notification.GetImage(_handle, NotiImage.Thumbnail, out pathPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get thumbnail Path");
                    return string.Empty;
                }

                if(pathPtr == IntPtr.Zero)
                    return string.Empty;

                path = Marshal.PtrToStringAuto(pathPtr);
                return path;
            }
            set
            {
                int ret = Interop.Notification.SetImage(_handle, NotiImage.Thumbnail, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set thumbnail path");
                }
            }
        }

        /// <summary>
        /// Method for setting Notification Appcontrol which is invoked when notification is clicked
        /// </summary>
        /// <param name="app">AppControl object to set</param>
        /// <example>
        /// <code>
        /// AppControl app = new AppControl();
        /// app.ApplicationId = "org.tizen.setting";
        /// Notification noti = new EventNotification();
        /// noti.SetLaunchAppControl(app);
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        public void SetLaunchAppControl(AppControl app)
        {
            if(app == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            int ret = Interop.Notification.SetAppControl(_handle, LaunchOption.AppControl, app.SafeAppControlHandle);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set app control");
            }
        }

        /// <summary>
        /// Method for getting Notification AppControl which will be invoked when notification is clicked
        /// </summary>
        /// <returns>AppControl object which was set</returns>
        /// <example>
        /// <code>
        /// AppControl app = new AppControl();
        /// app.ApplicationId = "org.tizen.setting";
        /// Notification noti = new EventNotification();
        /// noti.SetLaunchAppControl(app);
        /// /// ...
        /// AppControl clickApp = noti.GetLaunchAppControl();
        /// </code>
        /// </example>
        public AppControl GetLaunchAppControl()
        {
            SafeAppControlHandle app;
            int ret = Interop.Notification.GetAppControl(_handle, LaunchOption.AppControl, out app);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to get app control");
            }

            if(app.IsInvalid)
                return null;

            return new AppControl(app);
        }
    }
}
