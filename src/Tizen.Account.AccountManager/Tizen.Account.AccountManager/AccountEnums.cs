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
    /// Enumeration for the state of capability.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CapabilityState
    {
        /// <summary>
        /// Account capability is invalid.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidState,

        /// <summary>
        /// Account capability is disabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Disabled,

        /// <summary>
        /// Account capability is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Enabled
    }

    /// <summary>
    /// Enumeration for the state of account secrecy.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AccountSecrecyState
    {
        /// <summary>
        /// Account secrecy is invalid.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidState,

        /// <summary>
        /// Account is not visible.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Invisible,

        /// <summary>
        /// Account is visible.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Visible
    }

    /// <summary>
    /// Enumeration for the account sync status.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AccountSyncState
    {
        /// <summary>
        /// Account sync is invalid.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidState,

        /// <summary>
        /// Account sync not supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotSupported,

        /// <summary>
        /// Account sync supported, but all the synchronization functionalities are off.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Off,

        /// <summary>
        /// Account sync supported and sync status is idle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Idle,

        /// <summary>
        /// Account sync supported and sync status is running.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Running
    }

    /// <summary>
    /// Enumeration for the account auth type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AccountAuthType
    {
        /// <summary>
        /// Auth type is invalid.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Invalid,

        /// <summary>
        /// XAuth type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAuth,

        /// <summary>
        /// OAuth type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OAuth,

        /// <summary>
        /// ClientLogin type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ClientLogin
    }

    /// <summary>
    /// Account information change notification types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <remarks>
    /// When the account database is changed, you can distinguish one event type from the other which are set for subscribing notification.
    /// </remarks>
    public enum AccountNotificationType
    {
        /// <summary>
        /// The insert notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Insert,
        /// <summary>
        /// The delete notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Delete,
        /// <summary>
        /// The update notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Update,
        /// <summary>
        /// The sync update notification type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        syncUpdate
    }
}
