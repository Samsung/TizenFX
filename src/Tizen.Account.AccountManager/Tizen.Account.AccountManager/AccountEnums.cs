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

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// Enumeration for the state of capability
    /// </summary>
    public enum CapabilityState
    {
        /// <summary>
        /// Account capability is invalid
        /// </summary>
        InvalidState,

        /// <summary>
        /// Account capability is disabled
        /// </summary>
        Disabled,

        /// <summary>
        /// Account capability is enabled
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Enumeration for the state of account secrecy.
    /// </summary>
    public enum AccountSecrecyState
    {
        /// <summary>
        /// Account secrecy is invalid
        /// </summary>
        InvalidState,

        /// <summary>
        /// Account is not visible
        /// </summary>
        Invisible,

        /// <summary>
        /// Account is visible
        /// </summary>
        Visible
    }

    /// <summary>
    /// Enumeration for the account sync status.
    /// </summary>
    public enum AccountSyncState
    {
        /// <summary>
        /// Account sync is invalid
        /// </summary>
        InvalidState,

        /// <summary>
        /// Account sync not supported
        /// </summary>
        NotSupported,

        /// <summary>
        /// Account sync supported but all synchronization functionalities are off
        /// </summary>
        Off,

        /// <summary>
        /// Account sync support and sync status is idle
        /// </summary>
        Idle,

        /// <summary>
        /// Account sync support and sync status is running
        /// </summary>
        Running
    }

    /// <summary>
    /// Enumeration for the account auth type.
    /// </summary>
    public enum AccountAuthType
    {
        /// <summary>
        /// Auth type is invalid
        /// </summary>
        Invalid,

        /// <summary>
        /// XAuth type
        /// </summary>
        XAuth,

        /// <summary>
        /// OAuth type
        /// </summary>
        OAuth,

        /// <summary>
        /// Client-Login type
        /// </summary>
        ClientLogin
    }

    /// <summary>
    /// Account information change notification type
    /// </summary>
    /// <remarks>
    /// When the account database is changed, You can distinguish one event type from the other which are set for subscribing notification.
    /// </remarks>
    public enum AccountNotificationType
    {
        /// <summary>
        /// The insert notification type.
        /// </summary>
        Insert,
        /// <summary>
        /// The delete notification type.
        /// </summary>
        Delete,
        /// <summary>
        /// The update notification type.
        /// </summary>
        Update,
        /// <summary>
        /// The sync update notification type.
        /// </summary>
        syncUpdate
    }
}
