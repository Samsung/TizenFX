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

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// Event arguments passed when Event is triggered to notify that account is updated/removed from the account database.
    /// </summary>
    public class AccountSubscriberEventArgs : EventArgs
    {
        private const string NotiInsert = "insert";
        private const string NotiDelete = "delete";
        private const string NotiUpdate = "update";
        private const string NotiSyncUpdate = "sync_update";
        internal AccountSubscriberEventArgs(string eventType, int accountId)
        {
            if (eventType.CompareTo(NotiInsert) == 0)
            {
                EventType = AccountNotificationType.Insert;
            }
            else if (eventType.CompareTo(NotiDelete) == 0)
            {
                EventType = AccountNotificationType.Delete;
            }
            else if (eventType.CompareTo(NotiUpdate) == 0)
            {
                EventType = AccountNotificationType.Update;
            }
            else if (eventType.CompareTo(NotiSyncUpdate) == 0)
            {
                EventType = AccountNotificationType.syncUpdate;
            }

            AccountId = accountId;
        }

        /// <summary>
        /// The account event type
        /// </summary>
        public AccountNotificationType EventType
        {
            get;
            internal set;
        }

        /// <summary>
        /// The account ID to update
        /// </summary>
        public int AccountId
        {
            get;
            internal set;
        }
    }
}
