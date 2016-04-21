// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Applications;
using Tizen.Applications.Notifications;

internal static partial class Interop
{
    internal static class Notification
    {
        [DllImport(Libraries.Notification, EntryPoint = "notification_create")]
        internal static extern SafeNotificationHandle Create(NotificationType type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_free")]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_text")]
        internal static extern int GetText(SafeNotificationHandle handle, NotiText type, out IntPtr text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_text")]
        internal static extern int SetText(SafeNotificationHandle handle, NotiText type, string text, string key, int args);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_image")]
        internal static extern int GetImage(SafeNotificationHandle handle, NotiImage type, out IntPtr text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_image")]
        internal static extern int SetImage(SafeNotificationHandle handle, NotiImage type, string text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_time")]
        internal static extern int GetTime(SafeNotificationHandle handle, out int time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_time")]
        internal static extern int SetTime(SafeNotificationHandle handle, int time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_insert_time")]
        internal static extern int GetInsertTime(SafeNotificationHandle handle, out long time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_sound")]
        internal static extern int GetSound(SafeNotificationHandle handle, out SoundOption type, out IntPtr path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_sound")]
        internal static extern int SetSound(SafeNotificationHandle handle, SoundOption type, string path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_vibration")]
        internal static extern int GetVibration(SafeNotificationHandle handle, out VibrationOption type, out IntPtr path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_vibration")]
        internal static extern int SetVibration(SafeNotificationHandle handle, VibrationOption type, string path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_led")]
        internal static extern int GetLed(SafeNotificationHandle handle, out LedOption type, out int color);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_led")]
        internal static extern int SetLed(SafeNotificationHandle handle, LedOption type, int color);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_led_time_period")]
        internal static extern int GetLedTimePeriod(SafeNotificationHandle handle, out int on, out int off);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_led_time_period")]
        internal static extern int SetLedTimePeriod(SafeNotificationHandle handle, int on, int off);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_launch_option")]
        internal static extern int GetAppControl(SafeNotificationHandle handle, LaunchOption type, out SafeAppControlHandle apphandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_launch_option")]
        internal static extern int SetAppControl(SafeNotificationHandle handle, LaunchOption type, SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_event_handler")]
        internal static extern int GetEventHandler(SafeNotificationHandle handle, int type, out SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_event_handler")]
        internal static extern int SetEventHandler(SafeNotificationHandle handle, int type, SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_property")]
        internal static extern int GetProperties(SafeNotificationHandle handle, out int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_property")]
        internal static extern int SetProperties(SafeNotificationHandle handle, int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_display_applist")]
        internal static extern int GetApplist(SafeNotificationHandle handle, out int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_display_applist")]
        internal static extern int SetApplist(SafeNotificationHandle handle, int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_size")]
        internal static extern int GetProgressSize(SafeNotificationHandle handle, out double value);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_size")]
        internal static extern int SetProgressSize(SafeNotificationHandle handle, double value);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_progress")]
        internal static extern int GetProgress(SafeNotificationHandle handle, out double value);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_progress")]
        internal static extern int SetProgress(SafeNotificationHandle handle, double value);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_layout")]
        internal static extern int GetLayout(SafeNotificationHandle handle, out NotiLayout type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_layout")]
        internal static extern int SetLayout(SafeNotificationHandle handle, NotiLayout type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_type")]
        internal static extern int GetType(SafeNotificationHandle handle, out NotificationType type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_update")]
        internal static extern int Update(SafeNotificationHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_delete")]
        internal static extern int Delete(SafeNotificationHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_delete_all")]
        internal static extern int DeleteAll(int type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_post")]
        internal static extern int Post(SafeNotificationHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_pkgname")]
        internal static extern int GetPackageName(SafeNotificationHandle handle, out IntPtr name);

        [DllImport(Libraries.Notification, EntryPoint = "notification_add_button")]
        internal static extern int AddButton(SafeNotificationHandle handle, int index);

        [DllImport(Libraries.Notification, EntryPoint = "notification_remove_button")]
        internal static extern int RemoveButton(SafeNotificationHandle handle, int index);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_tag")]
        internal static extern int SetTag(SafeNotificationHandle handle, string tag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_tag")]
        internal static extern int GetTag(SafeNotificationHandle handle, out IntPtr tag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_status_message_post")]
        internal static extern int PostMessage(string text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_load_by_tag")]
        internal static extern SafeNotificationHandle Load(string text);

        internal sealed class SafeNotificationHandle : SafeHandle
        {
            public SafeNotificationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                Notification.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
