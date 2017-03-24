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
    internal static class ProgressBinder
    {
        internal static void BindObject(Notification notification)
        {
            double current, max;

            Notification.ProgressType progress = notification.Progress;
            Interop.Notification.SetProgressType(notification.Handle, progress.Category);

            if (progress.Category == ProgressCategory.PendingBar)
            {
                current = 0;
                max = 0;
            }
            else if (progress.Category == ProgressCategory.Percent)
            {
                current = progress.ProgressCurrent / 100;
                max = progress.ProgressMax;
            }
            else
            {
                current = progress.ProgressCurrent;
                max = progress.ProgressMax;
            }

            Interop.Notification.SetProgress(notification.Handle, current);
            Interop.Notification.SetProgressSize(notification.Handle, max);
            Interop.Notification.SetLayout(notification.Handle, NotificationLayout.Progress);
            Interop.Notification.SetOngoingFlag(notification.Handle, true);
        }

        internal static void BindSafeHandle(Notification notification)
        {
            NotificationLayout layout;
            Interop.Notification.GetLayout(notification.Handle, out layout);

            if (layout == NotificationLayout.Progress)
            {
                ProgressCategory category;
                double current, max;

                Interop.Notification.GetProgressType(notification.Handle, out category);
                Interop.Notification.GetProgress(notification.Handle, out current);
                Interop.Notification.GetProgressSize(notification.Handle, out max);

                if (category == ProgressCategory.Percent)
                {
                    current *= 100;
                }

                notification.Progress = new Notification.ProgressType(category, current, max);
            }
        }
    }
}