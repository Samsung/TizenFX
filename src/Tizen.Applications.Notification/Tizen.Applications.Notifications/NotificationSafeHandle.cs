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
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    /// <summary>
    /// This class manages the notification handle resources.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class NotificationSafeHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the NotificationSafeHandle class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }

        internal NotificationSafeHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(existingHandle);
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid
        {
            get { return this.DangerousGetHandle() == IntPtr.Zero; }
        }

        /// <summary>
        /// Executes the code required to free the NotificationSafeHandle.
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            Interop.Notification.Destroy(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
